package com.app.project.service;

import retrofit2.Call;
import okhttp3.ResponseBody;
import retrofit2.http.GET;

public interface APITable {

    @GET("get-all")
    Call<ResponseBody> getTables();
}
