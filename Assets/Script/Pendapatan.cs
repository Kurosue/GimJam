using UnityEngine;
using UnityEngine.UI;

public class IncomeManager : MonoBehaviour
{
    public int currentIncome = 0;
    public Text incomeText;  // UI Text untuk menampilkan pendapatan

    // Fungsi ini dapat dipanggil ketika kondisi terpenuhi
    public void IncreaseIncome(int amount)
    {
        currentIncome += amount;

        // Update UI atau lakukan sesuatu yang sesuai dengan game Anda
        UpdateIncomeUI();
    }

    void UpdateIncomeUI()
    {
        // Update teks UI dengan pendapatan terkini
        if (incomeText != null)
            incomeText.text = "Pendapatan: " + currentIncome;
    }
}