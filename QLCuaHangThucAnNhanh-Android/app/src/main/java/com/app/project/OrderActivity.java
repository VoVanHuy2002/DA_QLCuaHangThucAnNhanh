package com.app.project;

import androidx.annotation.ColorInt;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.app.Activity;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.app.project.adapter.CartAdapter;
import com.app.project.model.Customer;
import com.app.project.model.Food;
import com.app.project.model.UserAccount;
import com.app.project.service.APICustomer;
import com.app.project.service.APIOrder;
import com.app.project.service.CustomerClient;
import com.app.project.service.OrderClient;
import com.app.project.util.FormatCurrency;
import com.app.project.util.SharedPrefManager;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.sql.Date;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class OrderActivity extends AppCompatActivity implements CartAdapter.CartCloseCallBack {


    TextView textViewTotal, textViewDiscount, textViewNetTotal, textViewBackOrder, textViewClear, textViewCusName;
    EditText editTextPhoneCus;
    Button btnOrder, btnChooseCustomer;
    HashMap<Food, Integer> orderFood;
    RecyclerView recyclerViewOrder;
    CartAdapter cartAdapter;
    Customer customer = null;
    APICustomer api = CustomerClient.getInstance();
    APIOrder apiOrder = OrderClient.getInstance();
    Integer tableId;
    UserAccount userAccount = SharedPrefManager.getInstance(this).getUser();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_order);

        textViewTotal = findViewById(R.id.textViewTotal);
        textViewDiscount = findViewById(R.id.textViewDiscount);
        textViewNetTotal = findViewById(R.id.textViewNetTotal);
        textViewBackOrder = findViewById(R.id.textViewOrderBack);
        editTextPhoneCus = findViewById(R.id.editTextTextPhoneCus);
        btnOrder = findViewById(R.id.btnCheckout);
        recyclerViewOrder = findViewById(R.id.recycleViewCart);
        textViewClear = findViewById(R.id.textViewClear);
        btnChooseCustomer = findViewById(R.id.btnChooseCus);
        textViewCusName = findViewById(R.id.textViewCusName);

        // get data from intent
        try {
            tableId = getIntent().getIntExtra("tableId", 0);
            Bundle bundle = getIntent().getExtras();
            orderFood = (HashMap<Food, Integer>) bundle.getSerializable("orderFood");
            GridLayoutManager gridLayoutManager = new GridLayoutManager(OrderActivity.this, 1, GridLayoutManager.VERTICAL, false);
            recyclerViewOrder.setLayoutManager(gridLayoutManager);
            cartAdapter = new CartAdapter(orderFood, this);
            recyclerViewOrder.setAdapter(cartAdapter);
        } catch (Exception e) {
            Toast.makeText(this, "Error: " + e.getMessage(), Toast.LENGTH_SHORT).show();
            Log.e("ErrorErrorError:", e.getMessage());
        }

        btnOrder.setOnClickListener(v -> {
            if (editTextPhoneCus.getText().toString().isEmpty()) {
                editTextPhoneCus.setError("Please enter phone number");
                editTextPhoneCus.requestFocus();
                return;
            }

            if(customer == null){
                Toast.makeText(OrderActivity.this, "Vui lòng chọn khách hàng!", Toast.LENGTH_SHORT).show();
                return;
            }

            checkOut();
        });


        btnChooseCustomer.setOnClickListener(v -> {
            if (editTextPhoneCus.getText().toString().isEmpty()) {
                editTextPhoneCus.setError("Please enter phone number");
                editTextPhoneCus.requestFocus();
                return;
            }
            chooseCustomer();
        });

        textViewBackOrder.setOnClickListener(v -> {
            finish();
        });

        textViewClear.setOnClickListener(v -> {
            showConfirmationDialog();
        });
        textViewTotal.setText(FormatCurrency.formatCurrency(calculateTotal()));
        textViewDiscount.setText(calculateDiscount() + "%");
        textViewNetTotal.setText(FormatCurrency.formatCurrency(calculateTotal()));
    }

    private void checkOut() {
        HashMap<String, Object> payload = new HashMap<>();
        payload.put("customerId", customer.getCustomerId());
        payload.put("tableId", tableId);
        payload.put("employeeId", userAccount.getUserId());
        payload.put("total", calculateTotal());
        payload.put("discount", calculateDiscount());
        payload.put("netTotal", calculateTotal() * (1 - calculateDiscount() / 100));
        payload.put("dateBuy", String.valueOf(new Date(System.currentTimeMillis())));
        payload.put("status", "PENDING");
        payload.put("progress", "WAITING");

        // loop through orderFood to get foodId and quantity
        List<HashMap<String, Object>> orderItemsList = new ArrayList<>();
        for (Food food : orderFood.keySet()) {
            HashMap<String, Object> orderItem = new HashMap<>();
            orderItem.put("foodId", food.getFoodId());
            orderItem.put("quantity", orderFood.get(food));
            orderItem.put("total", food.getPrice() * orderFood.get(food));

            orderItemsList.add(orderItem);
        }
        payload.put("orderItems", orderItemsList);
        try {
            apiOrder.checkout(payload).enqueue(new Callback<ResponseBody>() {
                @Override
                public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response) {
                    try {
                        JSONObject obj = new JSONObject(response.body().string());
                        if (obj.getBoolean("success")) {
                            Toast.makeText(OrderActivity.this, "Đặt hàng thành công!", Toast.LENGTH_SHORT).show();
                            finish();
                            Intent intent = new Intent(OrderActivity.this, HomeActivity.class);
                            startActivity(intent);
                        } else {
                            Toast.makeText(OrderActivity.this, obj.getString("message"), Toast.LENGTH_SHORT).show();
                        }
                    } catch (JSONException e) {
                        Toast.makeText(OrderActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                        Log.e("OrderActivity >> checkOut >> JSONException:", e.getMessage());
                    } catch (IOException e) {
                        Toast.makeText(OrderActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                        Log.e("OrderActivity >> checkOut >> IOException:", e.getMessage());
                    }
                }

                @Override
                public void onFailure(Call<ResponseBody> call, Throwable t) {
                    Toast.makeText(getApplicationContext(), "Dịch vụ đăng tạm ngưng, vui lòng đăng nhập lại sau!", Toast.LENGTH_SHORT).show();
                    Log.e("LoginActivity >> onCreate >> onFailure:", t.getMessage());
                }
            });
        } catch (Exception e) {
            Log.e("OrderActivity >> ERROR: :", e.getMessage());
            Toast.makeText(this, "Error: " + e.getMessage(), Toast.LENGTH_SHORT).show();
        }
    }


    public void chooseCustomer() {
        api.getCustomerByPhone(editTextPhoneCus.getText().toString()).enqueue(new Callback<ResponseBody>() {
            @Override
            public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response) {
                try {
                    JSONObject obj = new JSONObject(response.body().string());
                    if (obj.getBoolean("success")) {
                        if (obj.isNull("data")) {
                            Toast.makeText(OrderActivity.this, "Không tìm thấy khách hàng!", Toast.LENGTH_SHORT).show();
                            editTextPhoneCus.setError("Không tìm thấy khách hàng!");
                            editTextPhoneCus.requestFocus();
                            return;
                        }
                        JSONObject customerJson = obj.getJSONObject("data");
                        customer = new Customer(customerJson);
                        Toast.makeText(OrderActivity.this, "Khách hàng: " + customer.getCustomerName(), Toast.LENGTH_SHORT).show();
                        textViewCusName.setText(customer.getCustomerName());
                        editTextPhoneCus.setError(null);
                        editTextPhoneCus.setEnabled(false);
                        btnChooseCustomer.setEnabled(false);
                        btnChooseCustomer.setText("Đã chọn");
                        textViewDiscount.setText(calculateDiscount() + "%");
                        textViewNetTotal.setText(FormatCurrency.formatCurrency(calculateTotal() * (1 - calculateDiscount() / 100)));
                        btnChooseCustomer.setBackgroundColor(getResources().getColor(R.color.darkGrey));
                        editTextPhoneCus.setBackground(getResources().getDrawable(R.drawable.input_disable));
                    } else {
                        Toast.makeText(OrderActivity.this, obj.getString("message"), Toast.LENGTH_SHORT).show();
                    }
                } catch (JSONException e) {
                    Toast.makeText(OrderActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                    Log.e("OrderActivity >> chooseCustomer >> JSONException:", e.getMessage());
                } catch (IOException e) {
                    Toast.makeText(OrderActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                    Log.e("OrderActivity >> chooseCustomer >> IOException:", e.getMessage());
                }
            }

            @Override
            public void onFailure(Call<ResponseBody> call, Throwable t) {
                Toast.makeText(getApplicationContext(), "Dịch vụ đăng tạm ngưng, vui lòng đăng nhập lại sau!", Toast.LENGTH_SHORT).show();
                Log.e("LoginActivity >> onCreate >> onFailure:", t.getMessage());
            }
        });
    }

    public double calculateDiscount() {
        if (customer != null) {
            if (customer.getPoint() >= 200) {
                return 5;
            } else if (customer.getPoint() >= 400) {
                return 10;
            } else if (customer.getPoint() >= 600) {
                return 15;
            } else if (customer.getPoint() >= 800) {
                return 20;
            }
        }
        return 0;
    }

    public Double calculateTotal() {
        Double total = 0.0;
        for (Food food : orderFood.keySet()) {
            total += food.getPrice() * orderFood.get(food);
        }
        return total;
    }

    private void showConfirmationDialog() {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Xác nhận").setMessage("Đồng ý xóa giỏ hàng?").setPositiveButton("Đồng ý", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                try {
                    orderFood.clear();
                    cartAdapter.notifyDataSetChanged();
                    closeCart();
                } catch (Exception e) {
                    Log.e("OrderActive >> showConfirmationDialog >> Exception:", e.getMessage());
                }
            }
        }).setNegativeButton("Hủy", null).show();
    }

    @Override
    public void closeCart() {
        Intent returnIntent = new Intent();
        Bundle bundle = new Bundle();
        bundle.putSerializable("result", orderFood);
        returnIntent.putExtras(bundle);
        setResult(Activity.RESULT_OK, returnIntent);
        finish();
    }

    @Override
    public void updateTotalPrice() {
        textViewTotal.setText(FormatCurrency.formatCurrency(calculateTotal()));
        textViewNetTotal.setText(FormatCurrency.formatCurrency(calculateTotal() * (1 - calculateDiscount() / 100)));
    }
}