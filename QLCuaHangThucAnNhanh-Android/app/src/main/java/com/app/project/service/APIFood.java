package com.app.project.service;

import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.http.GET;

public interface APIFood {
    @GET("get-all")
    Call<ResponseBody> getAllFood();
}
