package com.app.project.util;

import java.text.NumberFormat;
import java.util.Locale;

public class FormatCurrency {

    public static String formatCurrency(Double price) {
        NumberFormat nf = NumberFormat.getCurrencyInstance(new Locale("vi", "VN"));
        return nf.format(price);
    }

}
