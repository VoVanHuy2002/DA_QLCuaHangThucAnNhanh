package com.app.project.service;

public class CustomerClient extends BaseClient{
    private static final String BASE_URL = "http://localhost:8080/api/";
    private static final String BASE_URL_ONLINE = "http://" + IP_ADDRESS + ":8080/api/customer/";
    private static APICustomer api;

    public static APICustomer getInstance() {
        if (api == null) return createService(APICustomer.class, BASE_URL_ONLINE);
        return api;
    }
}
