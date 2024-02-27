package com.example.app.controller;


import com.example.app.payload.CustomerDTO;
import com.example.app.repo.CustomerRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.*;

@CrossOrigin("*")
@RestController
@RequestMapping("/customer")
@RequiredArgsConstructor
public class CustomerController {
    private final CustomerRepository customerRepository;

    @PostMapping("/get-by-phone")
    public ResponeVO getByPhone(@RequestBody Object phone) {
        var customer = customerRepository.findByPhoneAndStatus(String.valueOf(phone), "ACTIVE").orElse(null);
        return new ResponeVO("Get customer by phone success", customer, true);
    }
}
