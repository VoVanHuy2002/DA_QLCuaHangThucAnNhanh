package com.example.app.controller;


import com.example.app.repo.TableOrderRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@CrossOrigin("*")
@RestController
@RequiredArgsConstructor
@RequestMapping("/table")
public class TableController {

    private final TableOrderRepository tableOrderRepository;

    @GetMapping("/get-all")
    public ResponeVO getAllTable() {
        return new ResponeVO("Get all table success", tableOrderRepository.findAllByStatus("ACTIVE"), true);
    }

}
