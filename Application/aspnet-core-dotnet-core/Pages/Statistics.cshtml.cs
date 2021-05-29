using System.Data;
using FusionCharts.DataEngine;
using FusionCharts.Visualization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnet_core_dotnet_core.repo;
using aspnet_core_dotnet_core.Data;

namespace aspnet_core_dotnet_core.Pages
{
    public class StatisticsModel : PageModel
    {
        // create a public property. OnGet method() set the chart configuration json in this property.
        // When the page is being loaded, OnGet method will be  invoked
        public string ChartJson { get; internal set; }

        StatisticsRepository repo = new StatisticsRepository();
        public void OnGet()
        {

            // create data table to store data
            DataTable ChartData = new DataTable();
            // Add columns to data table
            ChartData.Columns.Add("Programming Language", typeof(System.String));
            ChartData.Columns.Add("Users", typeof(System.Double));
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
            column.Caption.Text = "Most rated Movies";
            // Set chart sub title
            column.SubCaption.Text = "2017-2018";
            // hide chart Legend
            column.Legend.Show = false;
            // set XAxis Text
            column.XAxis.Text = "Programming Language";
            // Set YAxis title
            column.YAxis.Text = "User";
            // set chart theme
            column.ThemeName = FusionChartsTheme.ThemeName.FUSION;
            // set chart rendering json
            ChartJson = column.Render();
        }
    }
}