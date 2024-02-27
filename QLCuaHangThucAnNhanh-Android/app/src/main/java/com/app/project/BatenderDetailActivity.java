package com.app.project;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.app.project.adapter.BatenderDetailAdapter;
import com.app.project.model.Order;
import com.app.project.model.Table;
import com.app.project.service.APIOrder;
import com.app.project.service.OrderClient;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.util.HashMap;

import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class BatenderDetailActivity extends AppCompatActivity {

    RecyclerView recyclerViewBatenderDetail;
    BatenderDetailAdapter batenderDetailAdapter;

    Button btnBatenderDetailDone, btnBatenderDetailInProgress;

    APIOrder apiOrder = OrderClient.getInstance();
    TextView textViewBatenderDetailBack;
    Order order;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_batender_detail);
        recyclerViewBatenderDetail = findViewById(R.id.recyclViewBatenderDetail);
        btnBatenderDetailDone = findViewById(R.id.btnDone);
        btnBatenderDetailInProgress = findViewById(R.id.btnInProgress);
        textViewBatenderDetailBack = findViewById(R.id.textViewBatenderBack);
        order = (Order) getIntent().getSerializableExtra("order");

        if(order.getProgress().equals("IN PROGRESS")) {
            btnBatenderDetailInProgress.setEnabled(false);
            btnBatenderDetailInProgress.setText("Đang xử lý");
            btnBatenderDetailInProgress.setClickable(false);
            btnBatenderDetailInProgress.setBackgroundColor(getResources().getColor(R.color.darkGrey));

            btnBatenderDetailDone.setEnabled(true);
            btnBatenderDetailDone.setClickable(true);
            btnBatenderDetailDone.setBackgroundColor(getResources().getColor(R.color.orange));
            btnBatenderDetailDone.setTextColor(getResources().getColor(R.color.white));
        }

        textViewBatenderDetailBack.setOnClickListener(v -> {
            finish();
        });

        GridLayoutManager gridLayoutManager = new GridLayoutManager(getApplicationContext(), 1, GridLayoutManager.VERTICAL, false);
        recyclerViewBatenderDetail.setLayoutManager(gridLayoutManager);
        batenderDetailAdapter = new BatenderDetailAdapter(order);
        recyclerViewBatenderDetail.setAdapter(batenderDetailAdapter);

        btnBatenderDetailDone.setOnClickListener(v -> {
            updateProgress("DONE");
            Intent intent = new Intent(BatenderDetailActivity.this, BatenderActivity.class);
            startActivity(intent);
            finish();
        });

        btnBatenderDetailInProgress.setOnClickListener(v -> {
//            updateProgress("IN PROGRESS");
            btnBatenderDetailInProgress.setEnabled(false);
            btnBatenderDetailInProgress.setText("Đang xử lý");
            btnBatenderDetailInProgress.setClickable(false);
            btnBatenderDetailInProgress.setBackgroundColor(getResources().getColor(R.color.darkGrey));

            btnBatenderDetailDone.setEnabled(true);
            btnBatenderDetailDone.setClickable(true);
            btnBatenderDetailDone.setBackgroundColor(getResources().getColor(R.color.orange));
            btnBatenderDetailDone.setTextColor(getResources().getColor(R.color.white));
        });
    }

    private synchronized void updateProgress(String status) {
        HashMap<String, Object> params = new HashMap<>();
        params.put("progress", status);
        params.put("orderId", order.getOrderId());

        apiOrder.updateProgress(params).enqueue(new Callback<ResponseBody>() {
            @Override
            public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response) {
            }
            @Override
            public void onFailure(Call<ResponseBody> call, Throwable t) {
                Toast.makeText(BatenderDetailActivity.this, "Service unavaiable", Toast.LENGTH_SHORT).show();
                Log.e("BatenderDetailActivity >> updateProgress >> onFailure:", t.getMessage());
            }
        });

    }
}