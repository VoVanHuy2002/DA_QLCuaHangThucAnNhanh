package com.app.project.model;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.Serializable;

public class OrderItem implements Serializable {
    private Integer orderItemId;
    private Integer orderId;
    private Integer foodId;
    private int quantity;
    private Double total;
    private Food food;

    public OrderItem(JSONObject obj) throws JSONException{
        this.orderItemId = obj.getInt("orderItemId");
        this.orderId = obj.getInt("orderId");
        this.foodId = obj.getInt("foodId");
        this.quantity = obj.getInt("quantity");
        this.total = obj.getDouble("total");
        this.food = new Food(obj.getJSONObject("food"));
    }

    public Integer getOrderItemId() {
        return orderItemId;
    }

    public Food getFood() {
        return food;
    }

    public void setFood(Food food) {
        this.food = food;
    }

    public void setOrderItemId(Integer orderItemId) {
        this.orderItemId = orderItemId;
    }

    public Integer getOrderId() {
        return orderId;
    }

    public void setOrderId(Integer orderId) {
        this.orderId = orderId;
    }

    public Integer getFoodId() {
        return foodId;
    }

    public void setFoodId(Integer foodId) {
        this.foodId = foodId;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public Double getTotal() {
        return total;
    }

    public void setTotal(Double total) {
        this.total = total;
    }
}
