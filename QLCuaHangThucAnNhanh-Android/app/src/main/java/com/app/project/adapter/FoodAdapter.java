package com.app.project.adapter;

import android.graphics.drawable.Drawable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.core.content.ContextCompat;
import androidx.recyclerview.widget.RecyclerView;

import com.app.project.R;
import com.app.project.model.Food;
import com.app.project.util.FormatCurrency;
import com.bumptech.glide.Glide;

import java.util.ArrayList;
import java.util.HashMap;

public class FoodAdapter extends RecyclerView.Adapter<FoodAdapter.ViewHolder> {

    public ArrayList<Food> foods;
    HashMap<Food, Integer> orderFood;
    Toast toastMessage;

    public FoodAdapter(ArrayList<Food> foods, HashMap<Food, Integer> orderFood) {
        this.foods = foods;
        this.orderFood = orderFood;
    }

    @NonNull
    @Override
    public FoodAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View inflate = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_row_food, parent, false);
        return new ViewHolder(inflate);
    }

    @Override
    public void onBindViewHolder(@NonNull FoodAdapter.ViewHolder holder, int position) {
        Food food = foods.get(position);
        holder.foodName.setText(food.getFoodName());
        holder.foodPrice.setText(FormatCurrency.formatCurrency(food.getPrice()));
        try {
            if (food.getFoodImageAdr() != null && !food.getFoodImageAdr().isEmpty() && !food.getFoodImageAdr().equals("null"))
                Glide.with(holder.foodImage.getContext()).load(food.getFoodImageAdr()).into(holder.foodImage);
            else
                Glide.with(holder.foodImage.getContext()).load(ContextCompat.getDrawable(holder.foodImage.getContext(), R.drawable.default_food)).into(holder.foodImage);
        } catch (Exception e) {
            Glide.with(holder.foodImage.getContext()).load(ContextCompat.getDrawable(holder.foodImage.getContext(), R.drawable.default_food)).into(holder.foodImage);
        }
        holder.orderFood.setOnClickListener(v -> {
            if (orderFood.containsKey(food)) {
                orderFood.put(food, orderFood.get(food) + 1);
            } else {
                orderFood.put(food, 1);
            }
            if (toastMessage != null) {
                toastMessage.cancel();
            }
            toastMessage = Toast.makeText(v.getContext(), "Đã thêm " + food.getFoodName() + " vào giỏ hàng", Toast.LENGTH_SHORT);
            toastMessage.show();
        });
    }

    @Override
    public int getItemCount() {
        return foods.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        TextView foodName, foodPrice, orderFood;
        ImageView foodImage;

        public ViewHolder(@NonNull View parent) {
            super(parent);
            foodName = parent.findViewById(R.id.textViewFoodName);
            foodPrice = parent.findViewById(R.id.textViewFoodPrice);
            foodImage = parent.findViewById(R.id.imageViewFoodImage);
            orderFood = parent.findViewById(R.id.textViewOrderFood);

        }
    }
}
