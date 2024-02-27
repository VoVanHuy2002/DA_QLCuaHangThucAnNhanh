package com.app.project;

import androidx.activity.result.ActivityResult;
import androidx.activity.result.ActivityResultCallback;
import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;
import android.widget.Toast;

import com.app.project.adapter.FoodAdapter;
import com.app.project.model.Food;
import com.app.project.service.APIFood;
import com.app.project.service.FoodClient;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;

import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class FoodActivity extends AppCompatActivity {

    TextView textViewBack, textViewNext, textTblName;
    RecyclerView recyclerViewFood;
    FoodAdapter foodAdapter;
    ArrayList<Food> foods;

    HashMap<Food, Integer> orderFood = new HashMap<>();

    APIFood api = FoodClient.getInstance();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_food);
        textViewBack = findViewById(R.id.textViewBack);
        textViewNext = findViewById(R.id.textViewNext);
        textTblName = findViewById(R.id.textView6);
        recyclerViewFood = findViewById(R.id.recycleViewFood);

        // get data of table from intent
        Integer tableId = getIntent().getIntExtra("tableId", 0);
        String tableName = getIntent().getStringExtra("tableName");
        textTblName.setText("Menu - Bàn số " + tableName);

        foods = new ArrayList<>();
        GridLayoutManager gridLayoutManager = new GridLayoutManager(getApplicationContext(), 1, GridLayoutManager.VERTICAL, false);
        recyclerViewFood.setLayoutManager(gridLayoutManager);

        initData();
        foodAdapter = new FoodAdapter(foods, orderFood);
        recyclerViewFood.setAdapter(foodAdapter);

        textViewBack.setOnClickListener(v -> {
            finish();
        });

        textViewNext.setOnClickListener(v -> {
            if (orderFood.isEmpty()) {
                Toast.makeText(FoodActivity.this, "Vui lòng chọn món ăn", Toast.LENGTH_SHORT).show();
                return;
            }
            try {
                Intent intent = new Intent(FoodActivity.this, OrderActivity.class);
                intent.putExtra("tableId", tableId);
                Bundle bundle = new Bundle();
                bundle.putSerializable("orderFood", orderFood);
                intent.putExtras(bundle);
                someActivityResultLauncher.launch(intent);
            } catch (Exception e) {
                Toast.makeText(FoodActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                Log.e("FoodActivity >> textViewNext >> Exception:", e.getMessage());
            }
        });
    }

    ActivityResultLauncher<Intent> someActivityResultLauncher = registerForActivityResult(
            new ActivityResultContracts.StartActivityForResult(),
            new ActivityResultCallback<ActivityResult>() {
                @Override
                public void onActivityResult(ActivityResult result) {
                    if (result.getResultCode() == Activity.RESULT_OK) {
                        // There are no request codes
                        Intent data = result.getData();

                        Bundle bundle = data.getExtras();
                        orderFood = (HashMap<Food, Integer>) bundle.getSerializable("result");
                        foodAdapter = new FoodAdapter(foods, orderFood);
                        recyclerViewFood.setAdapter(foodAdapter);
                    }
                }
            });

    private void initData() {
        api.getAllFood().enqueue(new Callback<ResponseBody>() {
            @Override
            public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response) {
                try {
                    JSONObject obj = new JSONObject(response.body().string());
                    if (obj.getBoolean("success")) {
                        JSONArray dataArray = obj.getJSONArray("data");
                        for (int i = 0; i < dataArray.length(); i++) {
                            JSONObject tableJson = dataArray.getJSONObject(i);
                            Food food = new Food(tableJson);
                            foods.add(food);
                        }
                        foodAdapter.notifyDataSetChanged();
                    } else {
                        Toast.makeText(FoodActivity.this, obj.getString("message"), Toast.LENGTH_SHORT).show();
                    }
                } catch (JSONException e) {
                    Toast.makeText(FoodActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                    Log.e("FoodActivity >> initData >> JSONException:", e.getMessage());
                } catch (IOException e) {
                    Toast.makeText(FoodActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                    Log.e("FoodActivity >> initData >> IOException:", e.getMessage());
                }
            }

            @Override
            public void onFailure(Call<ResponseBody> call, Throwable t) {
                Toast.makeText(FoodActivity.this, t.getMessage(), Toast.LENGTH_SHORT).show();
                Log.e("FoodActivity >> initData >> onFailure:", t.getMessage());
            }
        });
    }
}