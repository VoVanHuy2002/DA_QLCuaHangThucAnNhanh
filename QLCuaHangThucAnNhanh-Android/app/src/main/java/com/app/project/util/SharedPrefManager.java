package com.app.project.util;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;

import com.app.project.model.UserAccount;

public class SharedPrefManager {
    private static final String SHARED_PREF_NAME = "login";
    private static final String KEY_ID = "key-id";
    private static final String KEY_USERNAME = "key-username";
    private static final String KEY_PASSWORD = "key-password";
    private static final String KEY_FULLNAME = "key-fullName";
    private static final String KEY_GENDER = "key-gender";
    private static final String KEY_AGE = "key-age";
    private static final String KEY_ADDRESS = "key-address";
    private static final String KEY_PHONE = "key-phone";
    private static final String KEY_ROLE = "key-role";
    private static SharedPrefManager mInstance;
    private static Context ctx;

    private SharedPrefManager(Context context) {
        ctx = context;
    }

    public static synchronized SharedPrefManager getInstance(Context context) {
        if (mInstance == null) {
            mInstance = new SharedPrefManager(context);
        }
        return mInstance;
    }

    public void userLogin(UserAccount user) {
        SharedPreferences sharedPreferences = ctx.getSharedPreferences(SHARED_PREF_NAME, Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = sharedPreferences.edit();
        editor.putInt(KEY_ID, user.getUserId());
        editor.putString(KEY_USERNAME, user.getUsername());
        editor.putString(KEY_PASSWORD, user.getPassword());
        editor.putString(KEY_FULLNAME, user.getFullName());
        editor.putString(KEY_GENDER, user.getGender());
        editor.putInt(KEY_AGE, user.getAge());
        editor.putString(KEY_ADDRESS, user.getAddress());
        editor.putString(KEY_PHONE, user.getPhone());
        editor.putInt(KEY_ROLE, user.getRoleId());
        editor.apply();
    }

    public static boolean isLoggedIn() {
        SharedPreferences sharedPreferences = ctx.getSharedPreferences(SHARED_PREF_NAME, Context.MODE_PRIVATE);
        return sharedPreferences.getString(KEY_USERNAME, null) != null;
    }

    public static UserAccount getUser() {
        SharedPreferences sharedPreferences = ctx.getSharedPreferences(SHARED_PREF_NAME, Context.MODE_PRIVATE);
        UserAccount u = new UserAccount();
        u.setUserId(sharedPreferences.getInt(KEY_ID, -1));
        u.setUsername(sharedPreferences.getString(KEY_USERNAME, null));
        u.setPassword(sharedPreferences.getString(KEY_PASSWORD, null));
        u.setFullName(sharedPreferences.getString(KEY_FULLNAME, null));
        u.setGender(sharedPreferences.getString(KEY_GENDER, null));
        u.setAge(sharedPreferences.getInt(KEY_AGE, -1));
        u.setAddress(sharedPreferences.getString(KEY_ADDRESS, null));
        u.setPhone(sharedPreferences.getString(KEY_PHONE, null));
        u.setRoleId(sharedPreferences.getInt(KEY_ROLE, -1));
        return u;
    }


    public void logout() {
        SharedPreferences sharedPreferences = ctx.getSharedPreferences(SHARED_PREF_NAME, Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = sharedPreferences.edit();
        editor.clear();
        editor.apply();
    }
}
