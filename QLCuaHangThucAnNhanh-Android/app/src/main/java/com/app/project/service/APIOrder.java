package com.app.project.service;

import java.util.HashMap;

import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.PATCH;
import retrofit2.http.POST;

public interface APIOrder {
    @POST("create")
    Call<ResponseBody> checkout(@Body HashMap<String, Object> orderDTO);

    @POST("get-last-order-by-table-id")
    Call<ResponseBody> getLastOrderByTableId(@Body HashMap<String, Object> tableId);

    @PATCH("update-status")
    Call<ResponseBody> updateStatus(@Body HashMap<String, Object> orderDTO);

    @GET("get-all-waiting")
    Call<ResponseBody> getAllOrderWaiting();

    @GET("get-all-inprogress")
    Call<ResponseBody> getAllOrderInProgress();

    @PATCH("update-progress")
    Call<ResponseBody> updateProgress(@Body HashMap<String, Object> orderDTO);
}
