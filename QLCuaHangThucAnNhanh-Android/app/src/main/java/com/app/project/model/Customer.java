package com.app.project.model;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.Serializable;

public class Customer implements Serializable {
    private Integer customerId;
    private String customerName;
    private String phone;
    private double point = 0;
    private String status = "ACTIVE";

    public Customer(JSONObject obj) throws JSONException {
        customerId = obj.getInt("customerId");
        customerName = obj.getString("customerName");
        phone = obj.getString("phone");
        point = obj.getDouble("point");
        status = obj.getString("status");
    }


    public Integer getCustomerId() {
        return customerId;
    }

    public void setCustomerId(Integer customerId) {
        this.customerId = customerId;
    }

    public String getCustomerName() {
        return customerName;
    }

    public void setCustomerName(String customerName) {
        this.customerName = customerName;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public double getPoint() {
        return point;
    }

    public void setPoint(double point) {
        this.point = point;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }
}
