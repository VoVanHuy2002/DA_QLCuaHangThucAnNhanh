package com.example.app.repo;

import com.example.app.model.Roles;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;


@Repository
public interface RoleRepository extends JpaRepository<Roles, Integer> {
    Roles findByRoleName(String roleName);
}
