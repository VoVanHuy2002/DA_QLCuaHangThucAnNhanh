package com.app.project.service;

import java.util.HashMap;

import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface APICustomer {
    @POST("get-by-phone")
    Call<ResponseBody> getCustomerByPhone (@Body String phone);
}
