using System;

namespace Quartz
{
    public interface IJobConfigurator
    {
        /// <summary>
        /// Use a <see cref="JobKey" /> with the given name and default group to
        /// identify the JobDetail.
        /// </summary>
        /// <remarks>
        /// <para>If none of the 'withIdentity' methods are set on the JobBuilder,
        /// then a random, unique JobKey will be generated.</para>
        /// </remarks>
        /// <param name="name">the name element for the Job's JobKey</param>
        /// <returns>the updated JobBuilder</returns>
        /// <seealso cref="JobKey" />
        /// <seealso cref="IJobDetail.Key" />
        JobBuilder WithIdentity(string name);

        /// <summary>
        /// Use a <see cref="JobKey" /> with the given name and group to
        /// identify the JobDetail.
        /// </summary>
        /// <remarks>
        /// <para>If none of the 'withIdentity' methods are set on the JobBuilder,
        /// then a random, unique JobKey will be generated.</para>
        /// </remarks>
        /// <param name="name">the name element for the Job's JobKey</param>
        /// <param name="group"> the group element for the Job's JobKey</param>
        /// <returns>the updated JobBuilder</returns>
        /// <seealso cref="JobKey" />
        /// <seealso cref="IJobDetail.Key" />
        JobBuilder WithIdentity(string name, string group);

        /// <summary>
        /// Use a <see cref="JobKey" /> to identify the JobDetail.
        /// </summary>
        /// <remarks>
        /// <para>If none of the 'withIdentity' methods are set on the JobBuilder,
        /// then a random, unique JobKey will be generated.</para>
        /// </remarks>
        /// <param name="key">the Job's JobKey</param>
        /// <returns>the updated JobBuilder</returns>
        /// <seealso cref="JobKey" />
        /// <seealso cref="IJobDetail.Key" />
        JobBuilder WithIdentity(JobKey key);

        /// <summary>
        /// Set the given (human-meaningful) description of the Job.
        /// </summary>
        /// <param name="description"> the description for the Job</param>
        /// <returns>the updated JobBuilder</returns>
        /// <seealso cref="IJobDetail.Description" />
        JobBuilder WithDescription(string? description);

        /// <summary>
        /// Instructs the <see cref="IScheduler" /> whether or not the job
        /// should be re-executed if a 'recovery' or 'fail-over' situation is
        /// encountered.
        /// </summary>
        /// <remarks>
        /// If not explicitly set, the default value is <see langword="false" />.
        /// </remarks>
        /// <param name="shouldRecover"></param>
        /// <returns>the updated JobBuilder</returns>
        JobBuilder RequestRecovery(bool shouldRecover = true);

        /// <summary>
        /// Whether or not the job should remain stored after it is
        /// orphaned (no <see cref="ITrigger" />s point to it).
        /// </summary>
        /// <remarks>
        /// If not explicitly set, the default value is <see langword="false" />.
        /// </remarks>
        /// <param name="durability">the value to set for the durability property.</param>
        ///<returns>the updated JobBuilder</returns>
        /// <seealso cref="IJobDetail.Durable" />
        JobBuilder StoreDurably(bool durability = true);

        /// <summary>
        /// Add the given key-value pair to the JobDetail's <see cref="JobDataMap" />.
        /// </summary>
        ///<returns>the updated JobBuilder</returns>
        /// <seealso cref="IJobDetail.JobDataMap" />
        JobBuilder UsingJobData(string key, string value);

        /// <summary>
        /// Add the given key-value pair to the JobDetail's <see cref="JobDataMap" />.
        /// </summary>
        ///<returns>the updated JobBuilder</returns>
        /// <seealso cref="IJobDetail.JobDataMap" />
        JobBuilder UsingJobData(string key, int value);

        /// <summary>
        /// Add the given key-value pair to the JobDetail's <see cref="JobDataMap" />.
        /// </summary>
        ///<returns>the updated JobBuilder</returns>
        /// <seealso cref="IJobDetail.JobDataMap" />
        JobBuilder UsingJobData(string key, long value);

        /// <summary>
        /// Add the given key-value pair to the JobDetail's <see cref="JobDataMap" />.
        /// </summary>
        ///<returns>the updated JobBuilder</returns>
        /// <seealso cref="IJobDetail.JobDataMap" />
        JobBuilder UsingJobData(string key, float value);

        /// <summary>
        /// Add the given key-value pair to the JobDetail's <see cref="JobDataMap" />.
        /// </summary>
        ///<returns>the updated JobBuilder</returns>
        /// <seealso cref="IJobDetail.JobDataMap" />
        JobBuilder UsingJobData(string key, double value);

        /// <summary>
        /// Add the given key-value pair to the JobDetail's <see cref="JobDataMap" />.
        /// </summary>
        ///<returns>the updated JobBuilder</returns>
        /// <seealso cref="IJobDetail.JobDataMap" />
        JobBuilder UsingJobData(string key, bool value);

        /// <summary>
        /// Add the given key-value pair to the JobDetail's <see cref="JobDataMap" />.
        /// </summary>
        ///<returns>the updated JobBuilder</returns>
        /// <seealso cref="IJobDetail.JobDataMap" />
        JobBuilder UsingJobData(string key, Guid value);

        /// <summary>
        /// Add the given key-value pair to the JobDetail's <see cref="JobDataMap" />.
        /// </summary>
        ///<returns>the updated JobBuilder</returns>
        /// <seealso cref="IJobDetail.JobDataMap" />
        JobBuilder UsingJobData(string key, char value);

        /// <summary>
        /// Add all the data from the given <see cref="JobDataMap" /> to the
        /// <see cref="IJobDetail" />'s <see cref="JobDataMap" />.
        /// </summary>
        ///<returns>the updated JobBuilder</returns>
        /// <seealso cref="IJobDetail.JobDataMap" />
        JobBuilder UsingJobData(JobDataMap newJobDataMap);

        /// <summary>
        /// Replace the <see cref="IJobDetail" />'s <see cref="JobDataMap" /> with the
        /// given <see cref="JobDataMap" />.
        /// </summary>
        /// <param name="newJobDataMap"></param>
        /// <returns></returns>
        JobBuilder SetJobData(JobDataMap newJobDataMap);

        /// <summary>
        /// Instructs the <see cref="IScheduler" /> whether or not concurrent execution of the job should be disallowed.
        /// </summary>
        /// <param name="concurrentExecutionDisallowed">Indicates whether or not concurrent execution of the job should be disallowed.</param>
        /// <returns>
        /// The updated <see cref="JobBuilder"/>.
        /// </returns>
        /// <remarks>
        /// If not explicitly set, concurrent execution of a job is only disallowed if either the <see cref="IJobDetail.JobType"/> itself,
        /// one of its ancestors or one of the interfaces that it implements, is annotated with <see cref="DisallowConcurrentExecutionAttribute"/>.
        /// </remarks>
        /// <seealso cref="DisallowConcurrentExecutionAttribute"/>
        JobBuilder DisallowConcurrentExecution(bool concurrentExecutionDisallowed = true);

        /// <summary>
        /// Instructs the <see cref="IScheduler" /> whether or not job data should be re-stored when execution of the job completes.
        /// </summary>
        /// <param name="persistJobDataAfterExecution">Indicates whether or not job data should be re-stored when execution of the job completes.</param>
        /// <returns>
        /// The updated <see cref="JobBuilder"/>.
        /// </returns>
        /// <remarks>
        /// If not explicitly set, job data is only re-stored if either the <see cref="IJobDetail.JobType"/> itself, one of
        /// its ancestors or one of the interfaces that it implements, is annotated with <see cref="PersistJobDataAfterExecutionAttribute"/>.
        /// </remarks>
        /// <seealso cref="PersistJobDataAfterExecutionAttribute"/>
        JobBuilder PersistJobDataAfterExecution(bool persistJobDataAfterExecution = true);
    }
}