package com.example.app.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.io.Serializable;
import java.util.Set;


@Entity
@Table(name = "food")
@Setter
@Getter
@NoArgsConstructor
@AllArgsConstructor
public class Food implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer foodId;
    private String foodName;
    private String foodImage;
    private String foodImageAdr;
    private Double price;
    private String description;
    private String status = "ACTIVE";

    @OneToMany(mappedBy = "food", cascade = CascadeType.ALL)
    @JsonIgnore
    private Set<OrderItems> orderItems;
}
