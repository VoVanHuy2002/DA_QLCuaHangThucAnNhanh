package com.example.app.controller;


import com.example.app.model.OrderItems;
import com.example.app.model.Orders;
import com.example.app.payload.OrderDTO;
import com.example.app.repo.CustomerRepository;
import com.example.app.repo.OrderItemsRepository;
import com.example.app.repo.OrdersRepository;
import com.example.app.repo.TableOrderRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.*;

import java.sql.Date;

@CrossOrigin("*")
@RestController
@RequestMapping("/order")
@RequiredArgsConstructor
public class OrderController {

    private final OrdersRepository ordersRepository;
    private final OrderItemsRepository orderItemsRepository;
    private final CustomerRepository customerRepository;
    private final TableOrderRepository tableOrderRepository;
    private final Integer DEFAULT_POINT = 10000; // 10,000 VND = 1 point
    private final String WAITING = "WAITING";

    @PostMapping("/create")
    public ResponeVO createOrder(@RequestBody OrderDTO orderDTO) {

        // update available table
        var table = tableOrderRepository.findById(orderDTO.getTableId()).orElse(null);
        table.setAvailable("NO");
        tableOrderRepository.save(table);

        // update point customer
        var customer = customerRepository.findById(orderDTO.getCustomerId()).orElse(null);
        customer.setPoint(customer.getPoint() + (orderDTO.getNetTotal() / DEFAULT_POINT));
        customerRepository.save(customer);

        var _order = new Orders();
        _order.setTableId(orderDTO.getTableId());
        _order.setCustomerId(orderDTO.getCustomerId());
        _order.setEmployeeId(orderDTO.getEmployeeId());
        _order.setTotal(orderDTO.getTotal());
        _order.setDiscount(orderDTO.getDiscount());
        _order.setNetTotal(orderDTO.getNetTotal());
        _order.setDateBuy(Date.valueOf(orderDTO.getDateBuy()));
        _order.setStatus(orderDTO.getStatus());
        _order.setProgress(orderDTO.getProgress());

        var order = ordersRepository.save(_order);
        var orderId = order.getOrderId();
        orderDTO.getOrderItems().forEach(item -> {
            var _newOrderItem = new OrderItems();
            _newOrderItem.setOrderId(orderId);
            _newOrderItem.setFoodId(item.getFoodId());
            _newOrderItem.setQuantity(item.getQuantity());
            _newOrderItem.setTotal(item.getTotal());
            orderItemsRepository.save(_newOrderItem);
        });
        return new ResponeVO("Create order success", null, true);
    }


    @PostMapping("/get-last-order-by-table-id")
    public ResponeVO getLastOrderByTableId(@RequestBody OrderDTO order) {
        var o = ordersRepository.findFirstByTableIdAndStatusOrderByOrderIdDesc(order.getTableId(), "PENDING").orElse(null);
        return new ResponeVO("Get last order by table id success", o, true);
    }

    @PatchMapping("/update-status")
    public ResponeVO updateStatus(@RequestBody OrderDTO order) {
        var table = tableOrderRepository.findById(order.getTableId()).orElse(null);
        table.setAvailable("YES");
        tableOrderRepository.save(table);

        var o = ordersRepository.findById(order.getOrderId()).orElse(null);
        o.setStatus(order.getStatus());
        ordersRepository.save(o);
        return new ResponeVO("Update status success", null, true);
    }

    @GetMapping("/get-all-waiting")
    public ResponeVO getAllOrderWaiting() {
        return new ResponeVO("Get all order inprogress success", ordersRepository.findAllByProgress(WAITING), true);
    }

    @GetMapping("/get-all-inprogress")
    public ResponeVO getAllOrderInprogress() {
        return new ResponeVO("Get all order inprogress success", ordersRepository.findAllByProgress("IN PROGRESS"), true);
    }

    @PatchMapping("/update-progress")
    public ResponeVO updateProgress(@RequestBody OrderDTO order) {
        var o = ordersRepository.findById(order.getOrderId()).orElse(null);
        o.setProgress(order.getProgress());
        ordersRepository.save(o);
        return new ResponeVO("Update progress success", null, true);
    }

}
