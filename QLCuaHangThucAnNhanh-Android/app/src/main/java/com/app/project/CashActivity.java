package com.app.project;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.app.project.adapter.ConfirmAdapter;
import com.app.project.model.Customer;
import com.app.project.model.Food;
import com.app.project.model.Order;
import com.app.project.model.OrderItem;
import com.app.project.model.Table;
import com.app.project.model.UserAccount;
import com.app.project.service.APIOrder;
import com.app.project.service.OrderClient;
import com.app.project.util.FormatCurrency;
import com.app.project.util.SharedPrefManager;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import okhttp3.ResponseBody;

public class CashActivity extends AppCompatActivity {
    TextView textViewBackCheckout,
            textViewConfirmEmpName,
            textViewConfirmCusName,
            textViewConfirmTableName,
            textViewConfirmDate,
            textViewConfirmTotalBill,
            textViewConfirmDiscountBill,
            textViewConfirmNetTotal;

    Integer tableId;
    APIOrder api = OrderClient.getInstance();
    Order order;
    ArrayList<OrderItem> orderItems;
    Customer customer;
    UserAccount currentEmp;
    Table table;

    Button btnCash, btnBank;

    RecyclerView recyclerViewConfirm;
    ConfirmAdapter confirmAdapter;
    Context mContext;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cash);
        currentEmp = SharedPrefManager.getInstance(this).getUser();
        textViewBackCheckout = findViewById(R.id.textViewBackCheckout);
        textViewConfirmEmpName = findViewById(R.id.textViewConfirmEmpName);
        textViewConfirmCusName = findViewById(R.id.textViewConfirmCusName);
        textViewConfirmTableName = findViewById(R.id.textViewConfirmTableName);
        textViewConfirmDate = findViewById(R.id.textViewConfirmDate);
        recyclerViewConfirm = findViewById(R.id.recycleViewConfirm);
        textViewConfirmTotalBill = findViewById(R.id.textViewConfirmTotalBill);
        textViewConfirmDiscountBill = findViewById(R.id.textViewConfirmDiscountBill);
        textViewConfirmNetTotal = findViewById(R.id.textViewConfirmNetTotal);
        btnCash = findViewById(R.id.btnCash);
        btnBank = findViewById(R.id.btnBank);
        mContext = this;
        orderItems = new ArrayList<>();
        tableId = getIntent().getIntExtra("tableId", 0);
        initData();

        textViewBackCheckout.setOnClickListener(v -> {
            finish();
        });

        btnBank.setOnClickListener(v -> {
            updateOrderStatus("BANK");
        });

        btnCash.setOnClickListener(v -> {
            updateOrderStatus("CASH");
        });

    }

    private void updateOrderStatus(String status) {
        HashMap<String, Object> params = new HashMap<>();
        params.put("orderId", order.getOrderId());
        params.put("tableId", tableId);
        params.put("status", status);
        api.updateStatus(params).enqueue(new retrofit2.Callback<ResponseBody>() {
            @Override
            public void onResponse(retrofit2.Call<ResponseBody> call, retrofit2.Response<ResponseBody> response) {
                Intent intent = new Intent(CashActivity.this, HomeActivity.class);
                startActivity(intent);
            }

            @Override
            public void onFailure(retrofit2.Call<ResponseBody> call, Throwable t) {
                Toast.makeText(CashActivity.this, "Service unavaiable", Toast.LENGTH_SHORT).show();
            }
        });
    }

    private synchronized void initData() {
        HashMap<String, Object> params = new HashMap<>();
        params.put("tableId", tableId);
        api.getLastOrderByTableId(params).enqueue(new retrofit2.Callback<ResponseBody>() {
            @Override
            public void onResponse(retrofit2.Call<ResponseBody> call, retrofit2.Response<ResponseBody> response) {
                try {
                    JSONObject obj = new JSONObject(response.body().string());
                    if (obj.getBoolean("success")) {
                        JSONObject orderJson = obj.getJSONObject("data");
                        order = new Order(orderJson);
                        customer = new Customer(orderJson.getJSONObject("customer"));
                        JSONArray dataArray = orderJson.getJSONArray("orderItems");
                        for (int i = 0; i < dataArray.length(); i++) {
                            JSONObject orderItemJson = dataArray.getJSONObject(i);
                            OrderItem orderItem = new OrderItem(orderItemJson);
                            orderItems.add(orderItem);
                        }
                        table = new Table(orderJson.getJSONObject("tableOrder"));
                        textViewConfirmEmpName.setText(currentEmp.getFullName());
                        textViewConfirmCusName.setText(customer.getCustomerName());
                        textViewConfirmTableName.setText(table.getTableName());
                        textViewConfirmDate.setText(String.valueOf(order.getDateBuy()));
                        textViewConfirmTotalBill.setText(FormatCurrency.formatCurrency(order.getTotal()));
                        textViewConfirmDiscountBill.setText(order.getDiscount() + "%");
                        textViewConfirmNetTotal.setText(FormatCurrency.formatCurrency(order.getNetTotal()));


                        GridLayoutManager gridLayoutManager = new GridLayoutManager(CashActivity.this, 1, GridLayoutManager.VERTICAL, false);
                        recyclerViewConfirm.setLayoutManager(gridLayoutManager);
                        confirmAdapter = new ConfirmAdapter(orderItems, mContext);
                        recyclerViewConfirm.setAdapter(confirmAdapter);

                        if(!order.getProgress().equals("DONE")) {
                            btnCash.setEnabled(false);
                            btnCash.setClickable(false);
                            btnCash.setBackgroundColor(getResources().getColor(R.color.darkGrey));
                            btnBank.setEnabled(false);
                            btnBank.setClickable(false);
                            Toast.makeText(CashActivity.this, "Vui lòng đợi món ăn được mang ra", Toast.LENGTH_SHORT).show();
                            btnBank.setTextColor(getResources().getColor(R.color.white));
                            btnBank.setBackgroundColor(getResources().getColor(R.color.darkGrey));
                        }

                    }else{
                        Toast.makeText(CashActivity.this, obj.getString("message"), Toast.LENGTH_SHORT).show();
                    }
                } catch (IOException | JSONException e) {
                    Log.e("CashActivity >> initData >> onResponse", e.getMessage());
                    Toast.makeText(CashActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(retrofit2.Call<ResponseBody> call, Throwable t) {
                Toast.makeText(CashActivity.this, t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }
}