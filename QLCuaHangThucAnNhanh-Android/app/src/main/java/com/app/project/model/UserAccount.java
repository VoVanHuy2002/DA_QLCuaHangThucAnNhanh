package com.app.project.model;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.Serializable;
import java.sql.ResultSet;
import java.sql.SQLException;


public class UserAccount implements Serializable {
    private Integer userId;
    private String username;
    private String password;
    private String fullName;
    private String gender;
    private Integer age;
    private String address;
    private String phone;
    private Integer roleId;
    private String status;
    private Role role;

    public Integer getUserId() {
        return userId;
    }

    public void setUserId(Integer userId) {
        this.userId = userId;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getFullName() {
        return fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    public String getGender() {
        return gender;
    }

    public void setGender(String gender) {
        this.gender = gender;
    }

    public Integer getAge() {
        return age;
    }

    public void setAge(Integer age) {
        this.age = age;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public Integer getRoleId() {
        return roleId;
    }

    public void setRoleId(Integer roleId) {
        this.roleId = roleId;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public Role getRole() {
        return role;
    }

    public void setRole(Role role) {
        this.role = role;
    }

    public UserAccount() {

    }

    public UserAccount(JSONObject obj) throws JSONException {
        this.userId = obj.getInt("userId");
        this.username = obj.getString("username");
        this.password = obj.getString("password");
        this.fullName = obj.getString("fullName");
        this.gender = obj.getString("gender");
        this.age = Integer.parseInt(obj.getString("age").equals("null") ? "0" : obj.getString("age"));
        this.address = obj.getString("address");
        this.phone = obj.getString("phone");
        this.roleId = Integer.parseInt(obj.getString("roleId").equals("null") ? "0" : obj.getString("roleId"));
        this.status = obj.getString("status");
        this.role = new Role(obj.getJSONObject("roles"));
    }

    @Override
    public String toString() {
        return "UserAccount{" +
                "userId=" + userId +
                ", username='" + username + '\'' +
                ", password='" + password + '\'' +
                ", fullName='" + fullName + '\'' +
                ", gender='" + gender + '\'' +
                ", age=" + age +
                ", address='" + address + '\'' +
                ", phone='" + phone + '\'' +
                ", roleId=" + roleId +
                ", status='" + status + '\'' +
                ", role=" + role +
                '}';
    }
}
