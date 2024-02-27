package com.app.project.service;

public class TableClient extends BaseClient{
    private static final String BASE_URL = "http://localhost:8080/api/";
    private static final String BASE_URL_ONLINE = "http://" + IP_ADDRESS + ":8080/api/table/";
    private static APITable apiTableClient;

    public static APITable getInstance() {
        if (apiTableClient == null) return createService(APITable.class, BASE_URL_ONLINE);
        return apiTableClient;
    }
}
