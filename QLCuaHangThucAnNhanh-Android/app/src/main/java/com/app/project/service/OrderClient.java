package com.app.project.service;

public class OrderClient extends BaseClient{
    private static final String BASE_URL = "http://localhost:8080/api/";
    private static final String BASE_URL_ONLINE = "http://" + IP_ADDRESS + ":8080/api/order/";
    private static APIOrder api;

    public static APIOrder getInstance() {
        if (api == null) return createService(APIOrder.class, BASE_URL_ONLINE);
        return api;
    }
}
