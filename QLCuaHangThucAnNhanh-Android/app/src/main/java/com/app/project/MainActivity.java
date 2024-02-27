package com.app.project;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.StrictMode;
import android.widget.Button;
import android.widget.TextView;

import com.app.project.util.SharedPrefManager;

public class MainActivity extends AppCompatActivity {

    TextView btnGetStarted;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        boolean isLogin = SharedPrefManager.getInstance(this).isLoggedIn();
        if (isLogin) {
            if (SharedPrefManager.getInstance(this).getUser().getRoleId() == 2)
                startActivity(new Intent(MainActivity.this, BatenderActivity.class));
            else
                startActivity(new Intent(MainActivity.this, HomeActivity.class));
            finish();
        } else {
            btnGetStarted = findViewById(R.id.textViewGetStarted);
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(policy);
            btnGetStarted.setOnClickListener(v -> {
                startActivity(new Intent(MainActivity.this, LoginActivity.class));
            });
        }
    }
}