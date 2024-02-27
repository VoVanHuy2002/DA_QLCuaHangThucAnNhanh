package com.app.project.service;

public class FoodClient extends BaseClient{
    private static final String BASE_URL = "http://localhost:8080/api/";
    private static final String BASE_URL_ONLINE = "http://" + IP_ADDRESS + ":8080/api/food/";
    private static APIFood api;

    public static APIFood getInstance() {
        if (api == null) return createService(APIFood.class, BASE_URL_ONLINE);
        return api;
    }
}
