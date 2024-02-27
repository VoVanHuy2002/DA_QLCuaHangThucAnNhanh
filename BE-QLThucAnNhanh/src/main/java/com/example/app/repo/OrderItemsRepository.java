package com.example.app.repo;

import com.example.app.model.OrderItems;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;


@Repository
public interface OrderItemsRepository extends JpaRepository<OrderItems, Integer> {
}
