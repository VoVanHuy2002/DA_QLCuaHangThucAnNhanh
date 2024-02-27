package com.app.project.service;

public class AuthencationClient extends BaseClient {
    private static final String BASE_URL = "http://localhost:8080/api/";
    private static final String BASE_URL_ONLINE = "http://" + IP_ADDRESS + ":8080/api/";
    private static APIAthencation apiChatService;

    public static APIAthencation getInstance() {
        if (apiChatService == null) return createService(APIAthencation.class, BASE_URL_ONLINE);
        return apiChatService;
    }
}
