package com.example.app.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.io.Serializable;


@Entity
@Table(name = "order_items")
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class OrderItems implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer orderItemId;

    @Column(name = "order_id")
    private Integer orderId;

    @Column(name = "food_id")
    private Integer foodId;
    private int quantity;
    private Double total;

    @ManyToOne
    @JoinColumn(name = "order_id", insertable = false, updatable = false)
    @JsonIgnore
    private Orders orders;

    @ManyToOne
    @JoinColumn(name = "food_id", insertable = false, updatable = false)
    private Food food;
}
