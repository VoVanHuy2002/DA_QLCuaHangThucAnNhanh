package com.example.app.payload;


import lombok.Builder;
import lombok.Data;

@Data
@Builder
public class UserDTO {
    private Integer id;
    private String password;
    private String newPassword;
}
