package com.app.project.service;


import java.util.HashMap;
import java.util.List;

import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.Header;
import retrofit2.http.POST;

public interface APIAthencation {

    @POST("login")
    Call<ResponseBody> login (@Body HashMap<String, String> loginDTO);

    @POST("update-password")
    Call<ResponseBody> updatePassword (@Body HashMap<String, Object> updatePasswordDTO);
}
