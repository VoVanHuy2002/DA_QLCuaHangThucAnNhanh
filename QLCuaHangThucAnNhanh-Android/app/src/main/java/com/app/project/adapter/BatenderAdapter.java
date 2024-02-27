package com.app.project.adapter;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.app.project.BatenderDetailActivity;
import com.app.project.R;
import com.app.project.model.Order;

import java.util.ArrayList;

public class BatenderAdapter extends RecyclerView.Adapter<BatenderAdapter.ViewHolder> {

    ArrayList<Order> listWaitingOrder;
    Context context;
    public BatenderAdapter(ArrayList<Order> listWaitingOrder, Context context) {
        this.listWaitingOrder = listWaitingOrder;
        this.context = context;
    }


    @NonNull
    @Override
    public BatenderAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View inflate = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_row_batender, parent, false);
        return new BatenderAdapter.ViewHolder(inflate);
    }

    @SuppressLint("DefaultLocale")
    @Override
    public void onBindViewHolder(@NonNull BatenderAdapter.ViewHolder holder, int position) {
        Order order = listWaitingOrder.get(position);
        holder.textViewBatenderTableName.setText(String.format("Bàn số %s", order.getTable().getTableName()));
        holder.textViewBatenderCusName.setText(order.getCustomer().getCustomerName());
        holder.textViewBatenderNumberItem.setText(String.format("Số lượng món: %d", order.getOrderItems().size()));
        holder.itemView.setOnClickListener(v -> {
            Intent intent = new Intent(context, BatenderDetailActivity.class);
            Bundle bundle = new Bundle();
            bundle.putSerializable("order", order);
            intent.putExtras(bundle);
            context.startActivity(intent);
        });

    }

    @Override
    public int getItemCount() {
        return listWaitingOrder.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {

        TextView textViewBatenderTableName, textViewBatenderCusName, textViewBatenderNumberItem;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            textViewBatenderTableName = itemView.findViewById(R.id.textViewBatenderTableName);
            textViewBatenderCusName = itemView.findViewById(R.id.textViewBatenderCusName);
            textViewBatenderNumberItem = itemView.findViewById(R.id.textViewBatenderNumberItem);
        }
    }
}
