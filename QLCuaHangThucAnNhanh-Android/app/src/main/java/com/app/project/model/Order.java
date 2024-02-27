package com.app.project.model;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.Serializable;
import java.sql.Date;
import java.util.ArrayList;

public class Order implements Serializable {

    private Integer orderId;
    private Integer customerId;
    private Customer customer;
    private Integer tableId;
    private Table table;
    private Integer employeeId;
    private UserAccount employee;
    private Double total;
    private Double discount;
    private Double netTotal;
    private Date dateBuy;
    private String status = "PENDING";
    private String progress = "WAITING";

    private ArrayList<OrderItem> orderItems;

    public Customer getCustomer() {
        return customer;
    }

    public void setCustomer(Customer customer) {
        this.customer = customer;
    }

    public Table getTable() {
        return table;
    }

    public void setTable(Table table) {
        this.table = table;
    }

    public UserAccount getEmployee() {
        return employee;
    }

    public void setEmployee(UserAccount employee) {
        this.employee = employee;
    }

    public ArrayList<OrderItem> getOrderItems() {
        return orderItems;
    }

    public void setOrderItems(ArrayList<OrderItem> orderItems) {
        this.orderItems = orderItems;
    }

    public static Order getOrderByJSONObject(JSONObject obj) throws JSONException {
        Order order = new Order(obj);
        if (!obj.isNull("customer")) order.setCustomer(new Customer(obj.getJSONObject("customer")));
        if (!obj.isNull("tableOrder")) order.setTable(new Table(obj.getJSONObject("tableOrder")));

        ArrayList<OrderItem> orderItems = new ArrayList<>();
        JSONArray orderItemsJson = obj.getJSONArray("orderItems");
        for (int i = 0; i < orderItemsJson.length(); i++) {
            orderItems.add(new OrderItem(orderItemsJson.getJSONObject(i)));
        }
        order.setOrderItems(orderItems);
        return order;
    }

    public Order(JSONObject obj) throws JSONException {
        this.orderId = obj.getInt("orderId");
        this.customerId = Integer.parseInt(obj.getString("customerId").equals("null") ? "0" : obj.getString("customerId"));
        this.tableId = Integer.parseInt(obj.getString("tableId").equals("null") ? "0" : obj.getString("tableId"));
        this.employeeId = Integer.parseInt(obj.getString("employeeId").equals("null") ? "0" : obj.getString("employeeId"));
        this.total = obj.getDouble("total");
        this.discount = obj.getDouble("discount");
        this.netTotal = obj.getDouble("netTotal");
        this.dateBuy = Date.valueOf(obj.getString("dateBuy"));
        this.status = obj.getString("status");
        this.progress = obj.getString("progress");
    }

    public Integer getOrderId() {
        return orderId;
    }

    public void setOrderId(Integer orderId) {
        this.orderId = orderId;
    }

    public Integer getCustomerId() {
        return customerId;
    }

    public void setCustomerId(Integer customerId) {
        this.customerId = customerId;
    }

    public Integer getTableId() {
        return tableId;
    }

    public void setTableId(Integer tableId) {
        this.tableId = tableId;
    }

    public Integer getEmployeeId() {
        return employeeId;
    }

    public void setEmployeeId(Integer employeeId) {
        this.employeeId = employeeId;
    }

    public Double getTotal() {
        return total;
    }

    public void setTotal(Double total) {
        this.total = total;
    }

    public Double getDiscount() {
        return discount;
    }

    public void setDiscount(Double discount) {
        this.discount = discount;
    }

    public Double getNetTotal() {
        return netTotal;
    }

    public void setNetTotal(Double netTotal) {
        this.netTotal = netTotal;
    }

    public Date getDateBuy() {
        return dateBuy;
    }

    public void setDateBuy(Date dateBuy) {
        this.dateBuy = dateBuy;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getProgress() {
        return progress;
    }

    public void setProgress(String progress) {
        this.progress = progress;
    }
}
