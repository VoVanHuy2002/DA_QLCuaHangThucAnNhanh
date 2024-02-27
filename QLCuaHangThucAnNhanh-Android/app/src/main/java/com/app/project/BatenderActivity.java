package com.app.project;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import androidx.swiperefreshlayout.widget.SwipeRefreshLayout;

import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.app.project.adapter.BatenderAdapter;
import com.app.project.model.Order;
import com.app.project.model.UserAccount;
import com.app.project.service.APIOrder;
import com.app.project.service.OrderClient;
import com.app.project.util.SharedPrefManager;
import com.bumptech.glide.Glide;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.util.ArrayList;

import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class BatenderActivity extends AppCompatActivity {

    RecyclerView recyclerViewBatender;
    BatenderAdapter batenderAdapter;
    ArrayList<Order> listWaitingOrder;
    APIOrder apiOrder = OrderClient.getInstance();

    ImageView imageViewUserBatender;
    TextView textViewHiBatender, textViewInprogress, textWaiting;
    Context context;
    UserAccount currentUser;
    Boolean isWaiting = true;
    Toast toast;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_batender);
        recyclerViewBatender = findViewById(R.id.recycleViewBatender);
        imageViewUserBatender = findViewById(R.id.imageViewUserBatender);
        textViewHiBatender = findViewById(R.id.textViewHiBatender);

        textViewInprogress = findViewById(R.id.textViewInprogress);
        textWaiting = findViewById(R.id.textViewWaiting);

        textWaiting.setOnClickListener(v -> {
            listWaitingOrder.clear();
            initData();
            batenderAdapter.notifyDataSetChanged();
            textWaiting.setBackgroundColor(getResources().getColor(R.color.orange));
            textViewInprogress.setBackgroundColor(getResources().getColor(R.color.white));
            this.isWaiting = true;
        });


        textViewInprogress.setOnClickListener(v -> {
            this.isWaiting = false;
            listWaitingOrder.clear();
            initDataInprogress();
            batenderAdapter.notifyDataSetChanged();
        });

        currentUser = SharedPrefManager.getInstance(this).getUser();
        textViewHiBatender.setText(String.format("Xin chào,\n %s", currentUser.getFullName()));
        if (currentUser.getGender().equals("Nữ")) {
            Glide.with(imageViewUserBatender.getContext()).load(R.drawable.default_image_nu).circleCrop().into(imageViewUserBatender);
        }

        context = this;
        imageViewUserBatender.setOnClickListener(v -> {
            Intent intent = new Intent(BatenderActivity.this, ProfileActivity.class);
            startActivity(intent);
        });
        listWaitingOrder = new ArrayList<>();
        initData();

        final SwipeRefreshLayout pullToRefresh = findViewById(R.id.swipeRefreshLayout);
        pullToRefresh.setOnRefreshListener(() -> {
            listWaitingOrder.clear();
            if (isWaiting) {
                initData();
            } else {
                initDataInprogress();
            }
            batenderAdapter.notifyDataSetChanged();
            pullToRefresh.setRefreshing(false);
        });

    }

    private synchronized void initDataInprogress() {
        apiOrder.getAllOrderInProgress().enqueue(new Callback<ResponseBody>() {
            @Override
            public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response) {
                try {
                    JSONObject obj = new JSONObject(response.body().string());
                    if (obj.getBoolean("success")) {
                        JSONArray listOrderJson = obj.getJSONArray("data");
                        for (int i = 0; i < listOrderJson.length(); i++) {
                            JSONObject objOrder = listOrderJson.getJSONObject(i);
                            Order order = Order.getOrderByJSONObject(objOrder);
                            listWaitingOrder.add(order);
                        }
                        if (toast != null) {
                            toast.cancel();
                        }
                        toast = Toast.makeText(BatenderActivity.this, "Có " + listWaitingOrder.size() + " đơn hàng đang chờ pha chế", Toast.LENGTH_SHORT);
                        toast.show();
                        GridLayoutManager gridLayoutManager = new GridLayoutManager(getApplicationContext(), 1, GridLayoutManager.VERTICAL, false);
                        recyclerViewBatender.setLayoutManager(gridLayoutManager);
                        batenderAdapter = new BatenderAdapter(listWaitingOrder, context);
                        recyclerViewBatender.setAdapter(batenderAdapter);

                        textWaiting.setBackgroundColor(getResources().getColor(R.color.white));
                        textViewInprogress.setBackgroundColor(getResources().getColor(R.color.orange));
                    } else {
                        Toast.makeText(BatenderActivity.this, obj.getString("message"), Toast.LENGTH_SHORT).show();
                    }
                } catch (JSONException e) {
                    Toast.makeText(BatenderActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                    Log.e("BatenderActivity >> initData >> JSONException:", e.getMessage());
                } catch (IOException e) {
                    Toast.makeText(BatenderActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                    Log.e("BatenderActivity >> initData >> IOException:", e.getMessage());
                }
            }

            @Override
            public void onFailure(Call<ResponseBody> call, Throwable t) {
                Toast.makeText(getApplicationContext(), "Dịch vụ đăng tạm ngưng, vui lòng đăng nhập lại sau!", Toast.LENGTH_SHORT).show();
                Log.e("BatenderActivity >> initData >> onFailure:", t.getMessage());
            }
        });
    }

    private void showLogoutConfirmationDialog() {
        AlertDialog.Builder builder = new AlertDialog.Builder(BatenderActivity.this);
        builder.setTitle("Đăng xuất").setMessage("Bạn có muốn đăng xuất tài khoản này?").setPositiveButton("Đồng ý", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                try {
                    SharedPrefManager.getInstance(getApplicationContext()).logout();
                    Intent intent = new Intent(BatenderActivity.this, MainActivity.class);
                    startActivity(intent);
                } catch (Exception e) {
                    Log.e("BatenderActivity >> showLogoutConfirmationDialog >> Exception:", e.getMessage());
                }
            }
        }).setNegativeButton("Hủy", null).show();
    }

    private synchronized void initData() {
        apiOrder.getAllOrderWaiting().enqueue(new Callback<ResponseBody>() {
            @Override
            public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response) {
                try {
                    JSONObject obj = new JSONObject(response.body().string());
                    if (obj.getBoolean("success")) {
                        JSONArray listOrderJson = obj.getJSONArray("data");
                        for (int i = 0; i < listOrderJson.length(); i++) {
                            JSONObject objOrder = listOrderJson.getJSONObject(i);
                            Order order = Order.getOrderByJSONObject(objOrder);
                            listWaitingOrder.add(order);
                        }
                        if (toast != null) {
                            toast.cancel();
                        }
                        toast = Toast.makeText(BatenderActivity.this, "Có " + listWaitingOrder.size() + " đơn hàng đang chờ pha chế", Toast.LENGTH_SHORT);
                        toast.show();
                        GridLayoutManager gridLayoutManager = new GridLayoutManager(getApplicationContext(), 1, GridLayoutManager.VERTICAL, false);
                        recyclerViewBatender.setLayoutManager(gridLayoutManager);
                        batenderAdapter = new BatenderAdapter(listWaitingOrder, context);
                        recyclerViewBatender.setAdapter(batenderAdapter);
                    } else {
                        Toast.makeText(BatenderActivity.this, obj.getString("message"), Toast.LENGTH_SHORT).show();
                    }
                } catch (JSONException e) {
                    Toast.makeText(BatenderActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                    Log.e("BatenderActivity >> initData >> JSONException:", e.getMessage());
                } catch (IOException e) {
                    Toast.makeText(BatenderActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                    Log.e("BatenderActivity >> initData >> IOException:", e.getMessage());
                }
            }

            @Override
            public void onFailure(Call<ResponseBody> call, Throwable t) {
                Toast.makeText(getApplicationContext(), "Dịch vụ đăng tạm ngưng, vui lòng đăng nhập lại sau!", Toast.LENGTH_SHORT).show();
                Log.e("BatenderActivity >> initData >> onFailure:", t.getMessage());
            }
        });
    }
}