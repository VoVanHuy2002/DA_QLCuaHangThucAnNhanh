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
@Table(name = "user_account")
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class UserAccount implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer userId;
    private String username;
    private String password;
    private String fullName;
    private String gender;
    private Integer age;

    @Column(length = 500)
    private String address;

    @Column(length = 20)
    private String phone;

    @Column(name = "role_id")
    private Integer roleId;
    private String status;

    @OneToMany(mappedBy = "userAccount")
    @JsonIgnore
    private Set<Orders> orders;

    @ManyToOne
    @JoinColumn(name = "role_id", insertable = false, updatable = false)
    private Roles roles;
}
