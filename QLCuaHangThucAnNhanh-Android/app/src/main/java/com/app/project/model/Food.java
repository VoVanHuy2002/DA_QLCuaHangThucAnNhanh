package com.app.project.model;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.Serializable;

public class Food implements Serializable {
    private Integer foodId;
    private String foodName;
    private String foodImage;
    private String foodImageAdr;
    private Double price;
    private String description;
    private String status = "ACTIVE";

    public String getFoodImageAdr() {
        return foodImageAdr;
    }

    public void setFoodImageAdr(String foodImageAdr) {
        this.foodImageAdr = foodImageAdr;
    }

    public Food(Integer foodId, String foodName, String foodImage, Double price, String description, String status) {
        this.foodId = foodId;
        this.foodName = foodName;
        this.foodImage = foodImage;
        this.price = price;
        this.description = description;
        this.status = status;
    }
    public Food(JSONObject obj) throws JSONException {
        this.foodId = obj.getInt("foodId");
        this.foodName = obj.getString("foodName");
        this.foodImage = obj.getString("foodImage");
        this.foodImageAdr = obj.getString("foodImageAdr");
        this.price = obj.getDouble("price");
        this.description = obj.getString("description");
        this.status = obj.getString("status");
    }

    public Integer getFoodId() {
        return foodId;
    }

    public void setFoodId(Integer foodId) {
        this.foodId = foodId;
    }

    public String getFoodName() {
        return foodName;
    }

    public void setFoodName(String foodName) {
        this.foodName = foodName;
    }

    public String getFoodImage() {
        return foodImage;
    }

    public void setFoodImage(String foodImage) {
        this.foodImage = foodImage;
    }

    public Double getPrice() {
        return price;
    }

    public void setPrice(Double price) {
        this.price = price;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }
}
