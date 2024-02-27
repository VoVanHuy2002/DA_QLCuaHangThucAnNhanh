package com.example.app.controller;


import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.io.Serializable;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class ResponeVO implements Serializable {
    private String message;
    private Object data;
    private Boolean success;
}
