using Android.App;
using Android.OS;
using Android.Widget;
using Android.Views;
using System.Diagnostics;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Essentials;
using Microcharts;
using Microcharts.Droid;
using FinalProject.ArraySorter;
using Entry = Microcharts.ChartEntry;

namespace FinalProject
{
    [Activity(Label = "@string/arraySorter", Theme = "@style/AppTheme")]
    public class ArraySorterActivity : Activity
    {
        string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);

        string fileName = "numbers.txt";

        List<Entry> entries = new List<Entry>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.array_sorter_activity);
            EditText arrayText = FindViewById<EditText>(Resource.Id.ArrayText);
            Button sortButton = FindViewById<Button>(Resource.Id.SortButton);
            TextView bubbleSortedText = FindViewById<TextView>(Resource.Id.BubbleSortedArray);
            TextView cocktailSortedText = FindViewById<TextView>(Resource.Id.CocktailSortedArray);
            TextView insertionSortedText = FindViewById<TextView>(Resource.Id.InsertionSortedArray);
            TextView mergeSortedText = FindViewById<TextView>(Resource.Id.MergeSortedArray);
            TextView quickSortedText = FindViewById<TextView>(Resource.Id.QuickSortedArray);
            Button clearButton = FindViewById<Button>(Resource.Id.ClearButton);
            Button randButton = FindViewById<Button>(Resource.Id.RandButton);
            Button exportButton = FindViewById<Button>(Resource.Id.ExportButton);
            Button importButton = FindViewById<Button>(Resource.Id.ImportButton);
            Button goBackButton = FindViewById<Button>(Resource.Id.GoBackButton1);
            ChartView chartView = FindViewById<ChartView>(Resource.Id.chartView);

            string bubbleSortedArray = "";
            string cocktailSortedArray = "";
            string insertionSortedArray = "";
            string mergeSortedArray = "";
            string quickSortedArray = "";

            arrayText.KeyPress += (object sender, View.KeyEventArgs e) =>
            {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    Toast.MakeText(this, arrayText.Text, ToastLength.Short).Show();
                    e.Handled = true;
                }
            };

            sortButton.Clickable = true;
            clearButton.Clickable = false;

            clearButton.Click += (sende, e) =>
            {
                bubbleSortedText.Text = string.Empty;
                cocktailSortedText.Text = string.Empty;
                insertionSortedText.Text = string.Empty;
                mergeSortedText.Text = string.Empty;
                quickSortedText.Text = string.Empty;

                bubbleSortedArray = "";
                cocktailSortedArray = "";
                insertionSortedArray = "";
                mergeSortedArray = "";
                quickSortedArray = "";

                arrayText.Text = string.Empty;

                entries.Clear();
                chartView.Chart = new BarChart();

                sortButton.Clickable = true;
                clearButton.Clickable = false;
                randButton.Clickable = true;
            };

            sortButton.Click += (sender, e) =>
            {
                var nums = Parse(arrayText.Text);
                var stopwatch = new Stopwatch();

                if (nums.Count == 0)
                {
                    Toast.MakeText(this, "Array is empty.", ToastLength.Short).Show();
                }
                else
                {
                    //Bubble Sort
                    stopwatch.Restart();
                    BubbleSort.Sort(nums);
                    stopwatch.Stop();

                    bubbleSortedArray = ArrayToString(nums);

                    //Out Bubble Sort
                    if (!string.IsNullOrWhiteSpace(bubbleSortedArray))
                    {
                        bubbleSortedText.Text = "Bubble Sort: " + bubbleSortedArray;
                        if (BubbleSort.Counter != 0)
                        {
                            bubbleSortedText.Text += "\nIterations: " + BubbleSort.Counter.ToString();
                            bubbleSortedText.Text += "\nTime: " + stopwatch.ElapsedMilliseconds.ToString() + " ms.\n";
                        }
                    }

                    //Cocktail Sort
                    nums = Parse(arrayText.Text);

                    stopwatch.Restart();
                    CocktailSort.Sort(nums);
                    stopwatch.Stop();

                    cocktailSortedArray = ArrayToString(nums);

                    //Out Cocktail Sort
                    if (!string.IsNullOrWhiteSpace(cocktailSortedArray))
                    {
                        cocktailSortedText.Text = "Cocktail Sort: " + cocktailSortedArray;
                        if (CocktailSort.Counter != 0)
                        {
                            cocktailSortedText.Text += "\nIterations: " + CocktailSort.Counter.ToString();
                            cocktailSortedText.Text += "\nTime: " + stopwatch.ElapsedMilliseconds.ToString() + " ms.\n";
                        }
                    }

                    //Insertion Sort
                    nums = Parse(arrayText.Text);

                    stopwatch.Restart();
                    InsertionSort.Sort(nums);
                    stopwatch.Stop();

                    insertionSortedArray = ArrayToString(nums);

                    //Out Insertion Sort
                    if (!string.IsNullOrWhiteSpace(insertionSortedArray))
                    {
                        insertionSortedText.Text = "Insertion Sort: " + insertionSortedArray;
                        if (InsertionSort.Counter != 0)
                        {
                            insertionSortedText.Text += "\nIterations: " + InsertionSort.Counter.ToString();
                            insertionSortedText.Text += "\nTime: " + stopwatch.ElapsedMilliseconds.ToString() + " ms.\n";
                        }
                    }

                    //Merge Sort
                    nums = Parse(arrayText.Text);

                    stopwatch.Restart();
                    nums = MergeSort.Sort(nums);
                    stopwatch.Stop();

                    mergeSortedArray = ArrayToString(nums);

                    //Out Merge Sort
                    if (!string.IsNullOrWhiteSpace(mergeSortedArray))
                    {
                        mergeSortedText.Text = "Merge Sort: " + mergeSortedArray;
                        if (MergeSort.Counter != 0)
                        {
                            mergeSortedText.Text += "\nIterations: " + MergeSort.Counter.ToString();
                            mergeSortedText.Text += "\nTime: " + stopwatch.ElapsedMilliseconds.ToString() + " ms.\n";
                        }
                    }

                    //Quick Sort
                    nums = Parse(arrayText.Text);

                    stopwatch.Restart();
                    QuickSort.Sort(nums);
                    stopwatch.Stop();

                    quickSortedArray = ArrayToString(nums);

                    //Out Quick Sort
                    if (!string.IsNullOrWhiteSpace(quickSortedArray))
                    {
                        quickSortedText.Text = "Quick Sort: " + quickSortedArray;
                        if (QuickSort.Counter != 0)
                        {
                            quickSortedText.Text += "\nIterations: " + QuickSort.Counter.ToString();
                            quickSortedText.Text += "\nTime: " + stopwatch.ElapsedMilliseconds.ToString() + " ms.\n";
                        }
                    }

                    //Histogram
                    nums = Parse(arrayText.Text);
                    entries.Clear();
                    foreach (var n in nums)
                    {
                        entries.Add(
                            new Entry((float)n)
                            {
                                Label = n.ToString(),
                                ValueLabel = n.ToString(),
                                Color = SkiaSharp.SKColor.Parse("#00bfff")
                            });
                    }

                    chartView.Chart = new BarChart
                    {
                        Entries = entries
                    };
                    chartView.Chart.LabelTextSize = 30;
                }

                sortButton.Clickable = false;
                clearButton.Clickable = true;
            };

            randButton.Click += (sender, e) =>
            {
                arrayText.Text = FillRandom();
                clearButton.Clickable = true;
                randButton.Clickable = false;
                sortButton.Clickable = true;
            };

            exportButton.Click += (sender, e) =>
            {
                if (string.IsNullOrEmpty(arrayText.Text))
                {
                    Toast.MakeText(this, "Array is empty.", ToastLength.Short).Show();
                }
                else
                {
                    ExportArray(arrayText.Text);
                    Toast.MakeText(this, "Array has been exported to a file.", ToastLength.Short).Show();
                }
            };

            importButton.Click += (sender, e) =>
            {
                arrayText.Text = ImportArray(fileName);
                sortButton.Clickable = true;
                clearButton.Clickable = true;
            };

            goBackButton.Click += (sender, e) =>
            {
                this.Finish();
            };
        }

        private string ArrayToString(List<double> nums)
        {
            string res = "";
            for (int i = 0; i < nums.Count; i++)
            {
                if (i == nums.Count - 1)
                {
                    res += nums[i];
                }
                else
                {
                    res += nums[i] + ", ";
                }
            }
            return res;
        }

        private string FillRandom()
        {
            string res = "";
            var rnd = new Random();
            for (int i = 0; i < 9; i++)
            {
                res += rnd.Next(0, 100).ToString() + " ";
            }
            res += rnd.Next(0, 100).ToString();
            return res;
        }

        private async Task ExportArray(string nums)
        {
            try
            {
                var basePath = Path.Combine(FileSystem.AppDataDirectory, fileName);
                if (string.IsNullOrEmpty(basePath))
                {
                    throw new Exception("No valid storage for the app.");
                }
                using (var writer = File.CreateText(basePath))
                {
                    await writer.WriteAsync(nums);
                }
            }
            catch (Exception e)
            {
                Android.App.AlertDialog.Builder alertDialog = new Android.App.AlertDialog.Builder(this);
                alertDialog.SetTitle("Error");
                alertDialog.SetMessage(e.Message);
                alertDialog.SetNeutralButton("OK", delegate
                {
                    alertDialog.Dispose();
                });
                alertDialog.Show();
            }
        }

        private string ImportArray(string fileName)
        {
            try
            {
                var basePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

                if (string.IsNullOrEmpty(basePath) || !File.Exists(basePath))
                {
                    throw new Exception("File \"" + fileName + "\" is not exist.");
                }

                string res = "";

                using (var reader = new StreamReader(basePath, true))
                {
                    res = reader.ReadToEnd();
                }

                return res;
            }
            catch (Exception e)
            {
                Android.App.AlertDialog.Builder alertDialog = new Android.App.AlertDialog.Builder(this);
                alertDialog.SetTitle("Error");
                alertDialog.SetMessage(e.Message);
                alertDialog.SetNeutralButton("OK", delegate
                {
                    alertDialog.Dispose();
                });
                alertDialog.Show();
                return null;
            }
        }

        private List<double> Parse(string nums)
        {
            var array = new List<double>();
            if (!string.IsNullOrWhiteSpace(nums))
            {
                try
                {
                    string[] strNums = nums.Split(" ");
                    foreach (var n in strNums)
                    {
                        array.Add(Convert.ToDouble(n));
                    }
                    return array;
                }
                catch (Exception)
                {
                    Android.App.AlertDialog.Builder alertDialog = new Android.App.AlertDialog.Builder(this);
                    alertDialog.SetTitle("Error");
                    alertDialog.SetMessage("Cannot parse \"" + nums + "\" to array.");
                    alertDialog.SetNeutralButton("OK", delegate
                    {
                        alertDialog.Dispose();
                    });
                    alertDialog.Show();
                }
            }
            return array;
        }

    }
}