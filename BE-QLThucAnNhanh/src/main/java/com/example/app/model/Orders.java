package com.example.app.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.io.Serializable;
import java.sql.Date;
import java.util.Set;


@Entity
@Table(name = "orders")
@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
public class Orders implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer orderId;

    @Column(name = "customer_id")
    private Integer customerId;

    @Column(name = "table_id")
    private Integer tableId;

    @Column(name = "employe_id")
    private Integer employeeId;
    private Double total;
    private Double discount;
    private Double netTotal;
    private Date dateBuy;
    private String status = "PENDING";
    private String progress = "WAITING";

    @ManyToOne
    @JoinColumn(name = "customer_id", insertable = false, updatable = false)
    private Customer customer;

    @OneToMany(mappedBy = "orders", cascade = CascadeType.ALL)
    private Set<OrderItems> orderItems;

    @ManyToOne
    @JoinColumn(name = "employe_id", insertable = false, updatable = false)
    private UserAccount userAccount;

    @ManyToOne
    @JoinColumn(name = "table_id", insertable = false, updatable = false)
    private TableOrder tableOrder;
}
