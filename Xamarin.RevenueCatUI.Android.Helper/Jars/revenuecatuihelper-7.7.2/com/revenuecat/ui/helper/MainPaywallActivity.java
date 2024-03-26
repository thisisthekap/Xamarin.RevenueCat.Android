package com.revenuecat.ui.helper;

import androidx.annotation.OptIn;
import androidx.appcompat.app.AppCompatActivity;

import com.revenuecat.purchases.ui.revenuecatui.ExperimentalPreviewRevenueCatUIPurchasesAPI;
import com.revenuecat.purchases.ui.revenuecatui.activity.PaywallResult;
import com.revenuecat.purchases.ui.revenuecatui.activity.PaywallResultHandler;

@OptIn(markerClass = ExperimentalPreviewRevenueCatUIPurchasesAPI.class)
public abstract class MainPaywallActivity extends AppCompatActivity implements PaywallResultHandler {
    @Override
    public void onActivityResult(PaywallResult o) {
    }
}
