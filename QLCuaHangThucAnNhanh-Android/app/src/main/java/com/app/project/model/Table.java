package com.app.project.model;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.Serializable;

public class Table implements Serializable {
    private Integer tableId;
    private String tableName;
    private String description;
    private String status;
    private String available;

    public Table() {
    }

    public Table(Integer tableId, String tableName, String description, String status, String available) {
        this.tableId = tableId;
        this.tableName = tableName;
        this.description = description;
        this.status = status;
        this.available = available;
    }

    public Table(JSONObject obj) throws JSONException {
        this.tableId = obj.getInt("tableId");
        this.tableName = obj.getString("tableName");
        this.description = obj.getString("description");
        this.status = obj.getString("status");
        this.available = obj.getString("available");
    }

    public Integer getTableId() {
        return tableId;
    }

    public void setTableId(Integer tableId) {
        this.tableId = tableId;
    }

    public String getTableName() {
        return tableName;
    }

    public void setTableName(String tableName) {
        this.tableName = tableName;
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

    public String getAvailable() {
        return available;
    }

    public void setAvailable(String available) {
        this.available = available;
    }

    @Override
    public String toString() {
        return "Table{" +
                "tableId=" + tableId +
                ", tableName='" + tableName + '\'' +
                ", description='" + description + '\'' +
                ", status='" + status + '\'' +
                ", available='" + available + '\'' +
                '}';
    }
}
