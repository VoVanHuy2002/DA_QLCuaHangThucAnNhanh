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
import com.app.project.model.OrderItem;
import com.app.project.util.FormatCurrency;
import com.bumptech.glide.Glide;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class ConfirmAdapter extends RecyclerView.Adapter<ConfirmAdapter.ViewHoder> {

    ArrayList<OrderItem> listOrderItem;
    Context context;

    public ConfirmAdapter(ArrayList<OrderItem> listOrderItem, Context context) {
        this.listOrderItem = listOrderItem;
        this.context = context;
    }

    @NonNull
    @Override
    public ConfirmAdapter.ViewHoder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View inflate = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_row_confirm, parent, false);
        return new ConfirmAdapter.ViewHoder(inflate);
    }

    @Override
    public void onBindViewHolder(@NonNull ConfirmAdapter.ViewHoder holder, int position) {
        OrderItem orderItem = listOrderItem.get(position);
        Log.e("orderItem", orderItem.toString());
        holder.textViewConfirmFoodName.setText(orderItem.getFood().getFoodName());
        holder.textViewConfirmFoodPrice.setText(FormatCurrency.formatCurrency(orderItem.getFood().getPrice()));
        holder.textViewConfirmQuantity.setText(String.valueOf(orderItem.getQuantity()));
        holder.textViewConfirmTotal.setText(FormatCurrency.formatCurrency(orderItem.getTotal()));

        if (orderItem.getFood().getFoodImageAdr() != null && !orderItem.getFood().getFoodImageAdr().isEmpty() && !orderItem.getFood().getFoodImageAdr().equals("null"))
            Glide.with(holder.imageViewConfirmItem.getContext()).
                    load(orderItem.getFood().getFoodImageAdr()).
                    into(holder.imageViewConfirmItem);
        else {
            holder.imageViewConfirmItem.setImageResource(R.drawable.default_food);
        }

    }

    @Override
    public int getItemCount() {
        return listOrderItem.size();
    }

    public class ViewHoder extends RecyclerView.ViewHolder {

        ImageView imageViewConfirmItem;
        TextView textViewConfirmFoodName, textViewConfirmFoodPrice, textViewConfirmQuantity, textViewConfirmTotal;

        public ViewHoder(@NonNull View itemView) {
            super(itemView);
            imageViewConfirmItem = itemView.findViewById(R.id.imageViewConfirmItem);
            textViewConfirmFoodName = itemView.findViewById(R.id.textViewConfirmFoodName);
            textViewConfirmFoodPrice = itemView.findViewById(R.id.textViewConfirmFoodPrice);
            textViewConfirmQuantity = itemView.findViewById(R.id.textViewConfirmQuantity);
            textViewConfirmTotal = itemView.findViewById(R.id.textViewConfirmTotal);
        }
    }
}
