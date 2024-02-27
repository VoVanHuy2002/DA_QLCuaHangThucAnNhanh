package com.app.project;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.app.project.model.UserAccount;
import com.app.project.service.APIAthencation;
import com.app.project.service.AuthencationClient;
import com.app.project.util.SharedPrefManager;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginActivity extends AppCompatActivity {

    Button btnLogin;
    EditText etUsername, etPassword;
    TextView textViewResetPassword;
    APIAthencation apiAthencation = AuthencationClient.getInstance();

    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        btnLogin = findViewById(R.id.btnLogin);
        etUsername = findViewById(R.id.editTextPhone);
        etPassword = findViewById(R.id.editTextPassword);
        textViewResetPassword = findViewById(R.id.textViewResetPassword);

        textViewResetPassword.setOnClickListener(v -> {
            Toast.makeText(this, "Chức năng đang được phát triển", Toast.LENGTH_SHORT).show();
        });

        btnLogin.setOnClickListener(v -> {
            String username = etUsername.getText().toString();
            String password = etPassword.getText().toString();

            if (username.isEmpty()) {
                etUsername.setError("Username is required");
                etUsername.requestFocus();
                return;
            }

            if (password.isEmpty()) {
                etPassword.setError("Password is required");
                etPassword.requestFocus();
                return;
            }

            HashMap<String, String> map = new HashMap<>();
            map.put("username", username);
            map.put("password", password);

            apiAthencation.login(map).enqueue(new Callback<ResponseBody>() {
                @Override
                public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response) {
                    try {
                        JSONObject  obj = new JSONObject(response.body().string());
                        if (obj.getBoolean("success")) {
                            JSONObject userJson = obj.getJSONObject("data");
                            UserAccount user = new UserAccount(userJson);
                            SharedPrefManager.getInstance(LoginActivity.this).userLogin(user);
                            if(user.getRoleId() == 2) {
                                startActivity(new Intent(LoginActivity.this, BatenderActivity.class));
                            }else{
                                startActivity(new Intent(LoginActivity.this, HomeActivity.class));
                            }
                            finish();
                        } else {
                            Toast.makeText(LoginActivity.this, obj.getString("message"), Toast.LENGTH_SHORT).show();
                        }
                    } catch (JSONException e) {
                        Toast.makeText(LoginActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                        Log.e("LoginActivity >> onCreate >> JSONException:", e.getMessage());
                    } catch (IOException e) {
                        Toast.makeText(LoginActivity.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                        Log.e("LoginActivity >> onCreate >> IOException:", e.getMessage());
                    }
                }

                @Override
                public void onFailure(Call<ResponseBody> call, Throwable t) {
                    Toast.makeText(getApplicationContext(), "Dịch vụ đăng tạm ngưng, vui lòng đăng nhập lại sau!", Toast.LENGTH_SHORT).show();
                    Log.e("LoginActivity >> onCreate >> onFailure:", t.getMessage());
                }
            });
        });
    }

    private void goInToHome() {
        startActivity(new Intent(LoginActivity.this, HomeActivity.class));
        finish();
    }
}