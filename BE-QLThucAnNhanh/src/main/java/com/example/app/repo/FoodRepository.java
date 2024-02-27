package com.example.app.repo;

import com.example.app.model.Food;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;


@Repository
public interface FoodRepository extends JpaRepository<Food, Integer> {
    List<Food> findAllByStatus(String status);
}
