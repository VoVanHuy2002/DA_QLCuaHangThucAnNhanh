package com.example.app.payload;


import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.io.Serializable;
import java.sql.Date;
import java.util.List;
import java.util.Set;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class OrderDTO implements Serializable {
    private Integer orderId;
    private Integer customerId;
    private Integer tableId;
    private Integer employeeId;
    private Double total;
    private Double discount;
    private Double netTotal;
    private String dateBuy;
    private String status = "PENDING";
    private String progress = "WAITING";
    private Set<OrderItem> orderItems;
    @AllArgsConstructor
    @Data
    public static class OrderItem implements Serializable{
        private Integer foodId;
        private int quantity;
        private Double total;
    }
}
