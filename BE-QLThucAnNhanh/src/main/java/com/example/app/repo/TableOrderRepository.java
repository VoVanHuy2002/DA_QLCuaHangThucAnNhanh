package com.example.app.repo;

import com.example.app.model.TableOrder;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;


@Repository
public interface TableOrderRepository extends JpaRepository<TableOrder, Integer> {
    List<TableOrder> findAllByStatus(String status);
}
