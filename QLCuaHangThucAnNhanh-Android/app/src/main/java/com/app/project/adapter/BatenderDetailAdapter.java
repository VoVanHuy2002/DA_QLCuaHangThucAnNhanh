package com.app.project.adapter;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.app.project.R;
import com.app.project.model.Order;
import com.app.project.model.OrderItem;
import com.bumptech.glide.Glide;

import java.util.ArrayList;

public class BatenderDetailAdapter extends RecyclerView.Adapter<BatenderDetailAdapter.ViewHolder> {

    ArrayList<OrderItem> listOrderItem;
    Order order;

    public BatenderDetailAdapter(Order order) {
        this.order = order;
        this.listOrderItem = order.getOrderItems();
    }


    @NonNull
    @Override
    public BatenderDetailAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View inflate = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_row_batender_detail, parent, false);
        return new BatenderDetailAdapter.ViewHolder(inflate);
    }

    @Override
    public void onBindViewHolder(@NonNull BatenderDetailAdapter.ViewHolder holder, int position) {
        OrderItem orderItem = listOrderItem.get(position);
        holder.textViewBatenderDetailFoodName.setText(orderItem.getFood().getFoodName());
        holder.textViewBatenderDetailFoodQuantity.setText(String.format("Số lượng: %d", orderItem.getQuantity()));
        if (orderItem.getFood().getFoodImageAdr() != null && !orderItem.getFood().getFoodImageAdr().isEmpty() && !orderItem.getFood().getFoodImageAdr().equals("null"))
            Glide.with(holder.imageViewBatenderDetailFood.getContext()).load(orderItem.getFood().getFoodImageAdr()).into(holder.imageViewBatenderDetailFood);

    }

    @Override
    public int getItemCount() {
        return listOrderItem.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        TextView textViewBatenderDetailFoodName, textViewBatenderDetailFoodQuantity;
        ImageView imageViewBatenderDetailFood;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            textViewBatenderDetailFoodName = itemView.findViewById(R.id.textViewBatenderDetailFoodName);
            textViewBatenderDetailFoodQuantity = itemView.findViewById(R.id.textViewBatenderDetailFoodQuantity);
            imageViewBatenderDetailFood = itemView.findViewById(R.id.imageViewBatenderDetailFood);
        }
    }
}
