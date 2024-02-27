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
@Table(name = "table_order")
@Setter
@Getter
@NoArgsConstructor
@AllArgsConstructor
public class TableOrder implements Serializable {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer tableId;
    private String tableName;
    private String description;

    private String available = "YES";

    private String status = "ACTIVE";

    @OneToMany(mappedBy = "tableOrder", cascade = CascadeType.ALL)
    @JsonIgnore
    private Set<Orders> orders;
}
