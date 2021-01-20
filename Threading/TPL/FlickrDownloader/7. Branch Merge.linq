<Query Kind="Statements">
  <GACReference>System.Reactive, Version=1.0.2787.104, Culture=neutral, PublicKeyToken=31bf3856ad364e35</GACReference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Drawing</Namespace>
</Query>

AppDomain.CurrentDomain.UnhandledException += (sender, ex) => {
	ex.ExceptionObject.Dump("Unhandled");
};

var urls = new List<string>{
	"http://farm5.static.flickr.com/4037/4337491983_23f99f251c_o.jpg",
	"http://farm5.static.flickr.com/4021/4337490067_cc86d43978_o.jpg",
	"http://farm5.static.flickr.com/4052/4337488241_eb7cf71d66_o.jpg",
	"http://farm3.static.flickr.com/2735/4338230140_e440e5748e_o.jpg",
	"http://farm5.static.flickr.com/4003/4338228500_009e5d5a82_o.jpg",
};

var brokenImage = Image.FromStream(new WebClient().OpenRead("http://farm3.staticflickr.com/2585/3886756937_df3c326b02_s.jpg"));

var cancellationSource = new CancellationTokenSource();

var timeout = new Timer(o => cancellationSource.Cancel(), null, TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(-1));

var tasks = urls.Select(url => {
	
	// 1. Create web request
	var req = WebRequest.Create(url);
	
	// 2. Start get response
	var getResponseTask = Task<WebResponse>.Factory
		.FromAsync(req.BeginGetResponse, req.EndGetResponse, null);
		
	// 3. After response returns continue with reading the image
	var readImageTask = getResponseTask.ContinueWith<Image>(taskWebResponse => {
	
			// If we had a fail
			if (taskWebResponse.IsFaulted)
			{
				// Comment this out!!
				taskWebResponse.Exception.Handle(ex => ex is WebException);
				return brokenImage;
			}
	
			var response = taskWebResponse.Result;

			Image data;
			using(var stream = response.GetResponseStream())
			{
				data = Image.FromStream(stream);		
			}
			response.Close();
			
			return data;
		}, cancellationSource.Token);
		
	// 4. Image load task is the one we care about so return it
	return readImageTask;
});

// 5. Created and started all the tasks now so wait for them to complete
var final = Task.Factory.ContinueWhenAll<Image>(tasks.ToArray(), ts => {
	// 6. Extract the image results
	ts.Where(task => task.IsCanceled == false).Select(task => task.Result).Dump();
});

final.Wait();