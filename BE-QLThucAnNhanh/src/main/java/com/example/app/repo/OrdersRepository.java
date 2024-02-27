package com.example.app.repo;

import com.example.app.model.Orders;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;


@Repository
public interface OrdersRepository extends JpaRepository<Orders, Integer> {
    Optional<Orders> findFirstByTableIdAndStatusOrderByOrderIdDesc(int i, String status);

    List<Orders> findAllByProgress(String progress);

}
