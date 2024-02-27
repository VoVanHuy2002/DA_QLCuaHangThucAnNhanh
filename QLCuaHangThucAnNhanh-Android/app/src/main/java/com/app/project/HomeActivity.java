package com.app.project;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import androidx.swiperefreshlayout.widget.SwipeRefreshLayout;

import android.app.Activity;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.ImageView;
import android.widget.ScrollView;
import android.widget.TextView;
import android.widget.Toast;

import com.app.project.adapter.TableAdapter;
import com.app.project.model.Table;
import com.app.project.model.UserAccount;
import com.app.project.service.APIAthencation;
import com.app.project.service.APITable;
import com.app.project.service.AuthencationClient;
import com.app.project.service.TableClient;
import com.app.project.util.SharedPrefManager;
import com.bumptech.glide.Glide;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class HomeActivity extends AppCompatActivity {

    TableAdapter tableAdapter;
    RecyclerView recyclerView;
    ArrayList<Table> tables;

    APITable apiTable = TableClient.getInstance();

    UserAccount userAccount;
    TextView textViewHi;
    ImageView imageViewLogout;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);
        this.userAccount = SharedPrefManager.getInstance(this).getUser();
        tables = new ArrayList<>();
        recyclerView = findViewById(R.id.recyclerViewTable);
        textViewHi = findViewById(R.id.textViewHi);
        textViewHi.setText("Hi, " + userAccount.getFullName());
        GridLayoutManager gridLayoutManager = new GridLayoutManager(getApplicationContext(), 4, GridLayoutManager.VERTICAL, false);
        recyclerView.setLayoutManager(gridLayoutManager);
        initData();
        tableAdapter = new TableAdapter(tables, this, userAccount);
        recyclerView.setAdapter(tableAdapter);

        imageViewLogout = findViewById(R.id.imageViewLogout);


        if(userAccount.getGender().equals("Nữ")){
            Glide.with(imageViewLogout.getContext())
                    .load(R.drawable.default_image_nu)
                    .circleCrop()
                    .into(imageViewLogout);
        }


        imageViewLogout.setOnClickListener(v -> {
            Intent intent = new Intent(HomeActivity.this, ProfileActivity.class);
            startActivity(intent);
        });

        final SwipeRefreshLayout pullToRefresh = findViewById(R.id.swipeRefreshLayout);
        pullToRefresh.setOnRefreshListener(() -> {
            tables.clear();
            initData();
            tableAdapter.notifyDataSetChanged();
            pullToRefresh.setRefreshing(false);
        });
    }



    private void initData() {
        apiTable.getTables().enqueue(new Callback<ResponseBody>() {
            @Override
            public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response) {
                try {
                    JSONObject obj = new JSONObject(response.body().string());
                    if (obj.getBoolean("success")) {
                        JSONArray dataArray = obj.getJSONArray("data");
                        for (int i = 0; i < dataArray.length(); i++) {
                            JSONObject tableJson = dataArray.getJSONObject(i);
                            Table table = new Table(tableJson);
                            tables.add(table);
                        }
                        tableAdapter.notifyDataSetChanged();
                    } else {
                        Toast.makeText(HomeActivity.this, obj.getString("message"), Toast.LENGTH_SHORT).show();
                    }
                } catch (JSONException e) {
                    Toast.makeText(HomeActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                    Log.e("HomeActivity >> initData >> JSONException:", e.getMessage());
                } catch (IOException e) {
                    Toast.makeText(HomeActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                    Log.e("HomeActivity >> initData >> IOException:", e.getMessage());
                }
            }

            @Override
            public void onFailure(Call<ResponseBody> call, Throwable t) {
                Toast.makeText(HomeActivity.this, t.getMessage(), Toast.LENGTH_SHORT).show();
                Log.e("HomeActivity >> initData >> onFailure:", t.getMessage());
            }
        });
    }
}