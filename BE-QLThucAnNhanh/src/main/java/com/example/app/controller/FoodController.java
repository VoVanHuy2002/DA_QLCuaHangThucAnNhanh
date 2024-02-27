package com.example.app.controller;


import com.example.app.repo.FoodRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@CrossOrigin("*")
@RestController
@RequestMapping("/food")
@RequiredArgsConstructor
public class FoodController {
    private final FoodRepository foodRepository;

    @GetMapping("/get-all")
    public ResponeVO getAllFood() {
        return new ResponeVO("Get all food success", foodRepository.findAllByStatus("ACTIVE"), true);
    }
}
