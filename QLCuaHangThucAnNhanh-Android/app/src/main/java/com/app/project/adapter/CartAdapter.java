package com.app.project.adapter;

import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.app.project.R;
import com.app.project.model.Food;
import com.app.project.util.FormatCurrency;
import com.bumptech.glide.Glide;

import java.util.ArrayList;
import java.util.HashMap;

public class CartAdapter extends RecyclerView.Adapter<CartAdapter.ViewHoder> {

    HashMap<Food, Integer> orderFood;
    private CartCloseCallBack mCartCloseCallBack;

    public CartAdapter(HashMap<Food, Integer> orderFood, CartCloseCallBack context) {
        this.orderFood = orderFood;
        this.mCartCloseCallBack = context;
    }

    @NonNull
    @Override
    public CartAdapter.ViewHoder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View inflate = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_row_cart, parent, false);
        return new ViewHoder(inflate);
    }

    @Override
    public void onBindViewHolder(@NonNull CartAdapter.ViewHoder holder, int position) {

        try {
            Food food = (Food) orderFood.keySet().toArray()[position];
            Integer quantity = orderFood.get(food);

            holder.textViewFoodNameCart.setText(food.getFoodName());
            holder.textViewFoodPrice.setText(FormatCurrency.formatCurrency(food.getPrice()));
            holder.textViewQuantity.setText(quantity.toString());
            holder.textViewTotalPrice.setText(FormatCurrency.formatCurrency(food.getPrice() * quantity));

            if (food.getFoodImageAdr() != null && !food.getFoodImageAdr().isEmpty() && !food.getFoodImageAdr().equals("null"))
                Glide.with(holder.imageViewFoodCart.getContext()).
                        load(food.getFoodImageAdr()).
                        into(holder.imageViewFoodCart);
            else{
                holder.imageViewFoodCart.setImageResource(R.drawable.default_food);
            }

            holder.textViewAddQuantity.setOnClickListener(v -> {
                int currentQuantity = orderFood.get(food);
                orderFood.put(food, currentQuantity + 1);
                notifyDataSetChanged(); // Notify adapter that data has changed
                mCartCloseCallBack.updateTotalPrice();
            });

            holder.textViewSubQuantity.setOnClickListener(v -> {
                int currentQuantity = orderFood.get(food);
                if (currentQuantity > 1) {
                    orderFood.put(food, currentQuantity - 1);
                    notifyDataSetChanged(); // Notify adapter that data has changed
                    mCartCloseCallBack.updateTotalPrice();
                } else {
                    orderFood.remove(food);
                    notifyDataSetChanged(); // Notify adapter that data has changed
                    mCartCloseCallBack.updateTotalPrice();
                    if (orderFood.size() == 0) {
                        mCartCloseCallBack.closeCart();
                    }
                }
            });
        } catch (Exception e) {
            Log.e("ErrorErrorError:", e.getMessage());
        }
    }

    @Override
    public int getItemCount() {
        return orderFood.size();
    }

    public interface CartCloseCallBack {
        void closeCart();
        void updateTotalPrice();
    }

    public class ViewHoder extends RecyclerView.ViewHolder {
        ImageView imageViewFoodCart;
        TextView textViewFoodNameCart, textViewFoodPrice, textViewQuantity, textViewTotalPrice, textViewAddQuantity, textViewSubQuantity;

        public ViewHoder(@NonNull View itemView) {
            super(itemView);
            imageViewFoodCart = itemView.findViewById(R.id.imageViewFoodCart);
            textViewFoodNameCart = itemView.findViewById(R.id.textViewFoodNameCart);
            textViewFoodPrice = itemView.findViewById(R.id.textViewPriceOfFood);
            textViewTotalPrice = itemView.findViewById(R.id.textViewTotalItem);

            textViewAddQuantity = itemView.findViewById(R.id.textViewAddQuantity);
            textViewQuantity = itemView.findViewById(R.id.textViewQuantity);
            textViewSubQuantity = itemView.findViewById(R.id.textViewMinusQuantity);
        }
    }
}
