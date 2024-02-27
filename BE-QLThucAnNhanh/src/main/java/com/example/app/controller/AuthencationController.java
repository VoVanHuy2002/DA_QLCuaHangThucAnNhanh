package com.example.app.controller;


import com.example.app.payload.LoginDTO;
import com.example.app.payload.UserDTO;
import com.example.app.repo.UserAccountRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.*;

@CrossOrigin("*")
@RestController
@RequiredArgsConstructor
public class AuthencationController {

    private final UserAccountRepository userAccountRepository;

    @PostMapping("/login")
    public ResponeVO login(@RequestBody LoginDTO user) {
        var _user = userAccountRepository.findByUsername(user.getUsername());
        if (_user.isPresent()) {
            var result = _user.get();
            if (result.getPassword().equals(user.getPassword()) && result.getRoleId() != 1) {
                return new ResponeVO("Login success", result, true);
            }
        }
        return new ResponeVO("Tên đăng nhập hoặc mật khẩu không đúng", null, false);
    }

    @PostMapping("/update-password")
    public ResponeVO updatePassword(@RequestBody UserDTO user) {
        var _user = userAccountRepository.findById(user.getId());
        if (_user.isPresent()) {
            var result = _user.get();
            if (result.getPassword().equals(user.getPassword())) {
                result.setPassword(user.getNewPassword());
                userAccountRepository.save(result);
                return new ResponeVO("Cập nhật mật khẩu thành công", result, true);
            }
        }
        return new ResponeVO("Tên đăng nhập hoặc mật khẩu không đúng", null, false);
    }


    @GetMapping("/test")
    public String test() {
        return "test";
    }
}
