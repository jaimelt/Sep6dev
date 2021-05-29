using System.Data;
using FusionCharts.DataEngine;
using FusionCharts.Visualization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnet_core_dotnet_core.repo;
using aspnet_core_dotnet_core.Data;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_core_dotnet_core.Pages
{
    public class StatisticsModel : PageModel
    {
        // create a public property. OnGet method() set the chart configuration json in this property.
        // When the page is being loaded, OnGet method will be  invoked
        public string ChartJson { get; internal set; }
        public string ChartJson2 { get; internal set; }

        [BindProperty]
        public static int chartNumber { get; set; }

        StatisticsRepository repo = new StatisticsRepository();
        public void OnGet()
        {
            addChart();
        }

        public void OnPostVotes()
        {
            chartNumber = 1;
            OnGet();
        }
        public void OnPostRating()
        {
            chartNumber = 2;
            OnGet();
        }
        


        public void addChart()

        {       if (chartNumber ==1 )
                {
                MoviesByVotes();               
                }
            if (chartNumber == 2)
            {
                MoviesByRating();
            }
            System.Diagnostics.Debug.WriteLine("addChart if no works" + chartNumber);



        }

        public void MoviesByVotes()
        {
            System.Diagnostics.Debug.WriteLine("addChart if works" + chartNumber);

            // create data table to store data
            DataTable ChartData = new DataTable();
            // Add columns to data table
            ChartData.Columns.Add("Movie", typeof(System.String));
            ChartData.Columns.Add("Votes", typeof(System.Double));
            // Add rows to data table
            Movie[] movies = repo.getTop10VotedMovies();
            int index = 0;
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].votes);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].votes);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].votes);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].votes);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].votes);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].votes);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].votes);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].votes);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].votes);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].votes);

            // Create static source with this data table
            StaticSource source = new StaticSource(ChartData);
            // Create instance of DataModel class
            DataModel model = new DataModel();
            // Add DataSource to the DataModel
            model.DataSources.Add(source);
            // Instantiate Column Chart
            Charts.ColumnChart column = new Charts.ColumnChart("first_chart");
            // Set Chart's width and height
            column.Width.Pixel(700);
            column.Height.Pixel(400);
            // Set DataModel instance as the data source of the chart
            column.Data.Source = model;
            // Set Chart Title
            column.Caption.Text = "Most voted Movies";
            // Set chart sub title
            column.SubCaption.Text = "All times";
            // hide chart Legend
            column.Legend.Show = false;
            // set XAxis Text
            column.XAxis.Text = "Movies";
            // Set YAxis title
            column.YAxis.Text = "Votes";
            // set chart theme
            column.ThemeName = FusionChartsTheme.ThemeName.FUSION;
            // set chart rendering json
            ChartJson = column.Render();
        }


        public void MoviesByRating()
        {
            System.Diagnostics.Debug.WriteLine("addChart if works" + chartNumber);

            // create data table to store data
            DataTable ChartData = new DataTable();
            // Add columns to data table
            ChartData.Columns.Add("Movie", typeof(System.String));
            ChartData.Columns.Add("Votes", typeof(System.Double));
            // Add rows to data table
            Movie[] movies = repo.getTop10VotedMovies();
            int index = 0;
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].rating);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].rating);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].rating);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].rating);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].rating);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].rating);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].rating);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].rating);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].rating);
            ChartData.Rows.Add(movies[index].movieTitle, movies[index++].rating);


            // Create static source with this data table
            StaticSource source = new StaticSource(ChartData);
            // Create instance of DataModel class
            DataModel model = new DataModel();
            // Add DataSource to the DataModel
            model.DataSources.Add(source);
            // Instantiate Column Chart
            Charts.ColumnChart column = new Charts.ColumnChart("first_chart");
            // Set Chart's width and height
            column.Width.Pixel(700);
            column.Height.Pixel(400);
            // Set DataModel instance as the data source of the chart
            column.Data.Source = model;
            // Set Chart Title
            column.Caption.Text = "Most rated Movies";
            // Set chart sub title
            column.SubCaption.Text = "All times";
            // hide chart Legend
            column.Legend.Show = false;
            // set XAxis Text
            column.XAxis.Text = "Movies";
            // Set YAxis title
            column.YAxis.Text = "Votes";
            // set chart theme
            column.ThemeName = FusionChartsTheme.ThemeName.FUSION;
            // set chart rendering json
            ChartJson = column.Render();
        }

        public void TopUsersFavouriteMovies()
        {

        }





    }
}