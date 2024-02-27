package com.app.project;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.app.project.model.Food;
import com.app.project.model.UserAccount;
import com.app.project.service.APIAthencation;
import com.app.project.service.AuthencationClient;
import com.app.project.util.SharedPrefManager;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.util.HashMap;

import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ProfileActivity extends AppCompatActivity {
    EditText editTextCurrentPassword, editTextNewPassword, editTextConfirmPassword;
    TextView btnUpdatePassword, btnLogout;
    APIAthencation apiAthencation = AuthencationClient.getInstance();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_profile);
        editTextCurrentPassword = findViewById(R.id.editTextTextCurrentPassword);
        editTextNewPassword = findViewById(R.id.editTextTextNewPassword);
        editTextConfirmPassword = findViewById(R.id.editTextTextConfirmPassword);
        btnUpdatePassword = findViewById(R.id.btnUpdatePassword);
        btnLogout = findViewById(R.id.btnLogout);

        btnLogout.setOnClickListener(v -> {
            showLogoutConfirmationDialog();
        });

        btnUpdatePassword.setOnClickListener(v -> {
            String currentPassword = editTextCurrentPassword.getText().toString().trim();
            String newPassword = editTextNewPassword.getText().toString().trim();
            String confirmPassword = editTextConfirmPassword.getText().toString().trim();
            if (currentPassword.isEmpty()) {
                editTextCurrentPassword.setError("Mật khẩu hiện tại không được để trống");
                editTextCurrentPassword.requestFocus();
                return;
            }
            if (newPassword.isEmpty()) {
                editTextNewPassword.setError("Mật khẩu mới không được để trống");
                editTextNewPassword.requestFocus();
                return;
            }
            if (confirmPassword.isEmpty()) {
                editTextConfirmPassword.setError("Xác nhận mật khẩu không được để trống");
                editTextConfirmPassword.requestFocus();
                return;
            }
            if (!newPassword.equals(confirmPassword)) {
                editTextConfirmPassword.setError("Xác nhận mật khẩu không khớp");
                editTextConfirmPassword.requestFocus();
                return;
            }
            if (newPassword.length() < 6) {
                editTextNewPassword.setError("Mật khẩu mới phải có ít nhất 6 ký tự");
                editTextNewPassword.requestFocus();
                return;
            }
            if (currentPassword.equals(newPassword)) {
                editTextNewPassword.setError("Mật khẩu mới không được trùng với mật khẩu hiện tại");
                editTextNewPassword.requestFocus();
                return;
            }
            updatePassword(currentPassword, newPassword);
        });

    }

    private void updatePassword(String currentPassword, String newPassword) {
        HashMap<String, Object> map = new HashMap<>();
        map.put("password", currentPassword);
        map.put("newPassword", newPassword);
        UserAccount userAccount = SharedPrefManager.getInstance(this).getUser();
        map.put("id", userAccount.getUserId());
        apiAthencation.updatePassword(map).enqueue(new Callback<ResponseBody>() {
            @Override
            public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response) {
                try {
                    JSONObject obj = new JSONObject(response.body().string());
                    if (obj.getBoolean("success")) {
                        Toast.makeText(ProfileActivity.this, obj.getString("message"), Toast.LENGTH_SHORT).show();
                        SharedPrefManager.getInstance(ProfileActivity.this).logout();
                        Intent intent = new Intent(ProfileActivity.this, MainActivity.class);
                        startActivity(intent);
                    } else {
                        Toast.makeText(ProfileActivity.this, obj.getString("message"), Toast.LENGTH_SHORT).show();
                    }
                } catch (JSONException e) {
                    Log.e("ProfileActivity >> initData >> JSONException:", e.getMessage());
                } catch (IOException e) {
                    Log.e("ProfileActivity >> initData >> IOException:", e.getMessage());
                }
            }

            @Override
            public void onFailure(Call<ResponseBody> call, Throwable t) {
                Log.e("ProfileActivity >> initData >> onFailure:", t.getMessage());
            }
        });
    }

    private void showLogoutConfirmationDialog() {
        AlertDialog.Builder builder = new AlertDialog.Builder(ProfileActivity.this);
        builder.setTitle("Đăng xuất")
                .setMessage("Bạn có muốn đăng xuất tài khoản này?")
                .setPositiveButton("Đồng ý", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        try {
                            SharedPrefManager.getInstance(getApplicationContext()).logout();
                            Intent intent = new Intent(ProfileActivity.this, MainActivity.class);
                            startActivity(intent);
                        }catch (Exception e){
                            Log.e("ProfileActivity >> showLogoutConfirJmationDialog >> Exception:", e.getMessage());
                        }
                    }
                })
                .setNegativeButton("Hủy", null)
                .show();
    }
}