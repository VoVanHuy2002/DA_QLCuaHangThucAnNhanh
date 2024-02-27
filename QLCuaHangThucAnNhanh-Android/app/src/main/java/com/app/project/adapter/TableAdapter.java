package com.app.project.adapter;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.core.content.ContextCompat;
import androidx.recyclerview.widget.RecyclerView;

import com.app.project.CashActivity;
import com.app.project.FoodActivity;
import com.app.project.R;
import com.app.project.model.Table;
import com.app.project.model.UserAccount;

import java.util.ArrayList;

public class TableAdapter extends RecyclerView.Adapter<TableAdapter.ViewHoder> {
    public TableAdapter(ArrayList<Table> tables, Context context, UserAccount user) {
        this.mContext = context;
        this.tables = tables;
        this.employee = user;
    }

    private Context mContext;
    ArrayList<Table> tables;
    UserAccount employee;
    private final Integer ROLE_ORDER = 3;
    private final Integer ROLE_CASH = 4;
    Toast toast;


    @NonNull
    @Override
    public TableAdapter.ViewHoder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View inflate = LayoutInflater.from(parent.getContext()).inflate(R.layout.viewholder_table, parent, false);
        return new ViewHoder(inflate);
    }

    @Override
    public void onBindViewHolder(@NonNull TableAdapter.ViewHoder holder, int position) {
        holder.tableNumber.setText(tables.get(position).getTableName());
        switch (tables.get(position).getAvailable()) {
            case "YES":
                holder.tablelayout.setBackground(ContextCompat.getDrawable(holder.itemView.getContext(), R.drawable.table_avaiable));
                break;
            default:
                holder.tablelayout.setBackground(ContextCompat.getDrawable(holder.itemView.getContext(), R.drawable.table_unavaiable));
                break;
        }
        holder.itemView.setOnClickListener(v -> {
            if (tables.get(position).getAvailable().equals("YES") && employee.getRoleId() == ROLE_ORDER) {
                //TODO: Go to food menu
                Intent intent = new Intent(mContext, FoodActivity.class);
                intent.putExtra("tableId", tables.get(position).getTableId());
                intent.putExtra("tableName", tables.get(position).getTableName());
                mContext.startActivity(intent);
            } else if (tables.get(position).getAvailable().equals("NO") && employee.getRoleId() == ROLE_CASH) {
                Intent intent = new Intent(mContext, CashActivity.class);
                intent.putExtra("tableId", tables.get(position).getTableId());
                mContext.startActivity(intent);
            } else {

                if (toast != null) {
                    toast.cancel();
                }
                toast = Toast.makeText(mContext, "You can't access this table", Toast.LENGTH_SHORT);
                toast.show();
            }
        });
    }

    @Override
    public int getItemCount() {
        return tables.size();
    }

    public class ViewHoder extends RecyclerView.ViewHolder {
        TextView tableNumber;
        ConstraintLayout tablelayout;

        public ViewHoder(@NonNull View itemView) {
            super(itemView);
            tableNumber = itemView.findViewById(R.id.textViewTableName);
            tablelayout = itemView.findViewById(R.id.tablelayout);
        }
    }
}
